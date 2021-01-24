    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    namespace GoogleSearch
    {
        class LaunchFirefox
        {
            static void Main(string[] args)
            {
                    //Start Firefox Gecko Driver Service from Custom Location
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\FirefoxDriver");
    
                        //Force the CMD prompt window to automatically close and suppress diagnostic information
                            service.HideCommandPromptWindow = true;
                            service.SuppressInitialDiagnosticInformation = true;
    
                            //Initialize Firefox Options class
                                FirefoxOptions options = new FirefoxOptions();
    
                                //Set Custom Firefox Options
                                    options.BrowserExecutableLocation = @"C:\Mozilla Firefox\Firefox.exe";
                                    //options.AddArgument("--headless");
    
                //Start Firefox Driver with service, options, and timespan arguments
                    FirefoxDriver driver = new FirefoxDriver(service, options, TimeSpan.FromMinutes(1));
    
                //Navigate to the Google website
                    driver.Navigate().GoToUrl("https://www.google.com");
    
                //Automate custom Google Search Submission
                driver.FindElement(By.Name("q")).SendKeys("Stack Overflow");
            }
        }
        
    }
