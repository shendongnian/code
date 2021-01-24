    using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false }))
    using (var page = await browser.NewPageAsync())
    {
        await page.SetRequestInterceptionAsync(true);
    
        // disable images to download
        page.Request += (sender, e) =>
        {
            if (e.Request.ResourceType == ResourceType.Image)
                e.Request.AbortAsync();
            else
                e.Request.ContinueAsync();
        };
        await page.GoToAsync("https://www.kayak.com");
        Console.ReadLine();
    }
