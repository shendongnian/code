    string strTotalPrice = webDriver.FindElement(By.XPath("//span[@class='bag-subtotal-price']")).Text;
    int totalPrice = Convert.ToInt32(strTotalPrice);
    while(totalPrice <= 200)
    {
        // whatever code that increases totalPrice's value
    }
