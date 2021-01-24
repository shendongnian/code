     public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    public void ThatButtonIsHidden(string p0)
        {               
           
            if (p0.ToLower().Trim() == "submit an order")
            {
            bool isBtnPresent = IsElementPresent(By.Id("btn1Id"));
            Assert.IsFalse(isBtnPresent);                
            }
            else if (p0.ToLower().Trim() == "validate order")
            {
                bool isBtnPresent = IsElementPresent(By.Id("btn2Id"));
                Assert.IsFalse(isBtnPresent);
            }                 
                          
         }
