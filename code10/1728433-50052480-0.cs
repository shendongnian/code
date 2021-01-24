    var tasks = new List<Task>
            {
                new Task(PickUserFirefox)                
            };
            tasks.ForEach(
                task => task.Start()                
            );
            Task.WaitAll(tasks.ToArray());
        }
        private static void PickUserFirefox()
        {
            FirefoxTesting(StaticRandom.Instance.Next(1000,9999), "abcd");
        }
      private static void FirefoxTesting(int id, string fileIds)
        {
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"D:\Work\Testing\SelenimDriver\geckodriver.exe");
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(URL + id + "/" + fileIds);
            Thread.Sleep(1000);
             try
            {
                //Do something here
            }
            catch (Exception e)
            {
                //Error handle here
            }
            Thread.Sleep(1000);
            IWebElement btn = driver.FindElement(By.Id("btnSubmit"));
            btn.Click();
            Thread.Sleep(1000);
            //driver.Close();         
            driver.Quit();
        }
