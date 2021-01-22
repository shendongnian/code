    [WebMethod]
    public WebMethodResult DoSomethng(guid p_userId)
    {
    IfMethodIsSuccessful()
    {
        WebMethodResultSuccess successResult = new WebMethod();
        // Add required information into web method result object
    
       return successResult;
    }
    else
    {
       WebMethodResultFailure failedResult = new WebMethodResultFailure();
       return failedResult;
    }
    
    }
