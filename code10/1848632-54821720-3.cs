       public static bool existsElement(IWebDriver _driver,By by,int waitBySecond,string message)
        {
            WebDriverWait wait = new WebDriverWait(_driver, new TimeSpan(0, 0, waitBySecond));
            wait.Message = message;
            try
            {
                // check _driver.FindElement(by) or wait element to check
      
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("Message : " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return false;
            }
            catch(NoSuchElementException ex)
             {
               Console.WriteLine("Message : " + ex.Message);
               Console.WriteLine("StackTrace: " + ex.StackTrace);
              return false;
             }
            catch(Exception e)
            {
                Console.WriteLine("Message : " + wait.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return false;
            }
         
            return true;
        }
