    protected void Session_Start(object sender, EventArgs e)
    {
        var myObject = SomeMethodThatGetsMyObject();
        Session["MyObjectKey"] = myObject;
    }
    
    protected void Session_End(object sender, EventArgs e)
    {
        Session.Remove("MyObjectKey");
    }
