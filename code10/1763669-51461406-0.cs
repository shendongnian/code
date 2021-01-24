    using PuppeteerSharp;
    using System;
    using System.Threading.Tasks;
    
    namespace PuppeteerSharpDemo
    {
        class Program
        {
            private static String url = "http://www.oddsportal.com/matches/soccer/20180701/";
    
            static void Main(string[] args)
            {
                var htmlAsTask = LoadAndWaitForSelector(url, "#table-matches .table-main");
                htmlAsTask.Wait();
                Console.WriteLine(htmlAsTask.Result);
    
                Console.ReadKey();
            }
    
            public static async Task<string> LoadAndWaitForSelector(String url, String selector)
            {
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = @"c:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
                });
                using (Page page = await browser.NewPageAsync())
                {
                    await page.GoToAsync(url);
                    await page.WaitForSelectorAsync(selector);
                    return await page.GetContentAsync();
                }
            }
        }
    }
