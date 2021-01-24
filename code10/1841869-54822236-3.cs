     using OpenQA.Selenium;
     using NUnit.Framework;
      public void checknewTab(IWebDriver driver)
        {
           try
          {
            /* New tab window with  IJavaScriptExecutor */
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open();");
            /* Switch driver to last tab [which is blank tab] */
            driver.SwitchTo().Window(driver.WindowHandles.Last()); 
         
            /* Verify new Tab by using Assert  If it is was not about:blank - 
            It will throw AssertionException */
            Assert.AreEqual("about:blank", driver.Url); 
          }
         catch(AssertionException ex)
          {
               /* Print [Console.Writeline] that there is not a new Tab 
               [about:blank] */
          }
          catch(Exception ex)
         {
            // Print to see other Exception 
         }
            
            
        }
