        private static List<string> GetAllSources(IWebDriver driver)
        {
            var sources = new List<string>();
            driver.SwitchTo().DefaultContent();
            AddFrameSources(driver, sources);
            return sources;
        }
        private static void AddFrameSources(IWebDriver driver, List<string> sources)
        {
            sources.Add(driver.PageSource);
            var frames = driver.FindElements(By.TagName("frame"));
            var iframes = driver.FindElements(By.TagName("iframe"));
            foreach (var frame in frames.Union(iframes))
            {
                driver.SwitchTo().Frame(frame);
                AddFrameSources(driver, sources);
                driver.SwitchTo().ParentFrame();
            }
        }
