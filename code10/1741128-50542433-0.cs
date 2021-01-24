    public Task<IHttpActionResult> ControllerMethod() 
    {
        return A1();
    }
    public async Task<R1> A1() 
    {
        var result = await A2();
        if (result !=  null)
        {  
            A3() 
        }
        return result;
    }
    public Task<R1> A2() 
    {
        return A4();
    }
    public void A3() 
    {
        // call to another async method without await
    }
