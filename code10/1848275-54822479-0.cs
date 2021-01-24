       public static bool existsElement(IWebDriver _driver)
           {
   
            try
            {
              
                _driver.FindElement(by);
                        
            }
           
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Message : " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message : " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return false;
            }
            return true;
        }
