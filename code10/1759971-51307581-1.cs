    IWebElement country = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'validation-error')]")));  
    String errorMsg = country.Text();
    try{ 
    if(errorMsg.Trim().Contains("Please provide your postcode, as different regions have different fuel prices."))
    Console.WriteLine("Yes matched");
    }
    
    catch(Exception ex)
    {
    Console.WriteLine("Error msg did not match with the exact error msg");
    }
 
