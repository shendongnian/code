    [HttpPost]
    public UserSignUp(DeliveryAddressModel dam)
    {
        //Set this to the results sent back from your controller.
    
        Session["Name"] = dam.Name();
        Session["Line1"] = dam.Line1();
        Session["Line2"] = dam.Line2();
        Session["Line3"] = dam.Line3();
        .
        .
        .
        Session["Country "] = dam.Country();
    
    }
       
