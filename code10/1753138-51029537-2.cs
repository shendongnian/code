            //Extract the price from the cart
            string totalPrice = webDriver.FindElement(By.XPath("//span[@class='bag-subtotal-price']")).Text;
            double currentTotalPrice = Convert.ToDouble(totalPrice.Substring(1));
            double itemPerPrice = currentTotalPrice;
            // Just hardcoded the expected price limit value
            int priceLimit = 200;
            int quantity = 1;
            while(currentTotalPrice < priceLimit && priceLimit-currentTotalPrice > itemPerPrice)
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//select[contains(@class,'bag-item-quantity')]")));
                IWebElement qty = webDriver.FindElement(By.XPath("//select[contains(@class,'bag-item-quantity')]"));
                //Quantity values are rounded off with nearest lowest value . Example, 5.55 will be considered as 5 quantity
                SelectElementFromDropDown(qty, (++quantity).ToString());
                //After updating the quantity, update  button will be displayed dynamically.So, wait is added and then update action is performed
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@class='bag-item-edit-update']")));
                webDriver.FindElement(By.XPath("//button[@class='bag-item-edit-update']")).Click();
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@class='bag-subtotal-price']")));
                var temp = webDriver.FindElement(By.XPath("//span[@class='bag-subtotal-price']")).Text;
                currentTotalPrice = Convert.ToDouble(temp.Substring(1));
                Console.WriteLine("Current Price :" + currentTotalPrice);
            }
