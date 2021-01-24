    WebResponse rsp;
    try 
    {
       rsp = req.GetResponse();
    }
    catch(WebException ex) 
    {
        if(ex.Message.Contains("301"))
            rsp = ex.Result;
    }
