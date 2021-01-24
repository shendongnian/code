     try
     {
         label1.Text = "Finding route";
         string sxp = "//*[@id='s']";
         driver.FindElement(By.XPath(sxp)).Click();
         label1.Text = "sxp done";
     }
     catch(Exception e)
     {
         CheckRoute();
         label1.Text = "Exception thrown";
     }
     catch(ElementNotFoundException e)
     {
         Console.WriteLine(e.Message());
     }
