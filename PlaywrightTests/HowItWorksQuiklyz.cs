using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HowItWorksQuiklyz : PageTest
{
    [Test]

    public async Task HowItWorksURL()
    {

        await using var browser = await Playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            SlowMo = 100
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://uat.quiklyz.com");
        await page.GetByText("Chennai", new() { Exact = true }).ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "How it Works" }).ClickAsync();
        await page.GetByRole(AriaRole.Menuitem, new() { Name = "Car Subscription Process" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/how-car-leasing-individuals-India/car-lease-process");
        await page.Locator("button").Filter(new() { HasText = "Browse Cars" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/car-lease-search");
        await page.GoBackAsync();
        await page.WaitForLoadStateAsync();
        await page.Locator("button").Filter(new() { HasText = "Check Eligibility" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/login");
        await page.GetByRole(AriaRole.Button, new() { Name = "How it Works" }).ClickAsync();
        await page.GetByRole(AriaRole.Menuitem, new() { Name = "Subscription Benefits" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/how-car-leasing-individuals-India/car-lease-benefits");
        await page.Locator("button").Filter(new() { HasText = "Quiklyz Subscription" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/page/4e15b08e-061d-42fd-9b8c-0d5bdfbc4571/4063b97b-f531-44e4-a880-5c597913d106");
        await page.GoBackAsync();
        await page.Locator("button").Filter(new() { HasText = "Find your Car" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/car-lease-search");
        await page.GoBackAsync();
        await page.WaitForLoadStateAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "How it Works" }).ClickAsync();
        await page.GetByRole(AriaRole.Menuitem, new() { Name = "Ask an Expert" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/contact-us");
        await page.GetByRole(AriaRole.Button, new() { Name = "How it Works" }).ClickAsync();
        await page.GetByRole(AriaRole.Menuitem, new() { Name = "Videos" }).ClickAsync();
        await Expect(page).ToHaveURLAsync("https://uat.quiklyz.com/videos");
        Console.WriteLine("URLs are successfully validated");
    }
}