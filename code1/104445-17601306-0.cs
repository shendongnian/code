    [WebMethod]
    public void MyMethod(double requiredParam1, int requiredParam2)
    {
        // Grab an optional param from the request.
        string optionalParam1 = this.Context.Request["optionalParam1"];
        
        // Grab another optional param from the request, this time a double.
        double optionalParam2;
        double.TryParse(this.Context.Request["optionalParam2"], out optionalParam2);
        ...
    }
 
