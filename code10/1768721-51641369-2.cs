            var links = driver.FindElements(By.TagName("a"));
            for (int i=0; i < links.Count(); i++)
            {
                var newLinks = driver.FindElements(By.TagName("a"));
                newLinks[i].Click();
                driver.Navigate().Back();
            }
