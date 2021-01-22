    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        var myObject = SomeMethodThatGetsMyObject();
        HttpContext.Current.Items.Add("MyObjectKey", myObject);
    }
    
    protected void Application_EndRequest(object sender, EventArgs e)
    {
        HttpContext.Current.Items.Remove("MyObjectKey");
    }
      
