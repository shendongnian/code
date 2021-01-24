                IWebDriver webDriver = new ChromeDriver();
                webDriver.Navigate().GoToUrl("http://www.asos.com/men/");
                webDriver.Manage().Window.Maximize();
                webDriver.FindElement(By.XPath(".//input[@data-testid='search-input']")).SendKeys("nike trainers");
                webDriver.FindElement(By.XPath(".//button[@data-testid='search-button-inline']")).Click();
           
                //Search Result rendering will take some times.So, Explicit wait is mandatory
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                IWebElement country = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("article img")));
                webDriver.FindElement(By.CssSelector("article img")).Click();
    
                IWebElement Size = webDriver.FindElement(By.XPath(".//select[@data-id='sizeSelect']"));
                SelectElementFromDropDown(Size, "UK 10 - EU 45 - US 11");
    
                webDriver.FindElement(By.XPath("//*[@data-bind='text: buttonText']")).Click();
    
                //Add to cart takes some time.So, the below condition is needed 
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Added']")));
    
                webDriver.FindElement(By.XPath("//a[@data-testid='bagIcon']")).Click();
                //Wait condition is needed after the page load
                //wait.Until(ExpectedConditions.TitleContains("Shopping"));
         
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//select[contains(@class,'bag-item-quantity')]")));
                //Extract the price from the cart
                string totalPrice =webDriver.FindElement(By.XPath("//span[@class='bag-subtotal-price']")).Text;
                //Extract the price amount by exluding the currency
                double pricePerItem = Convert.ToDouble(totalPrice.Substring(1));
                
                // Just hardcoded the expected price limit value
                int priceLimit = 200;
        
                double noOfQuantity = priceLimit / pricePerItem;
    
                IWebElement qty =webDriver.FindElement(By.XPath("//select[contains(@class,'bag-item-quantity')]"));
                //Quantity values are rounded off with nearest lowest value . Example, 5.55 will be considered as 5 quantity
                SelectElementFromDropDown(qty, Math.Floor(noOfQuantity).ToString());
    
                //After updating the quantity, update  button will be displayed dynamically.So, wait is added and then update action is performed
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@class='bag-item-edit-update']")));
                webDriver.FindElement(By.XPath("//button[@class='bag-item-edit-update']")).Click();
