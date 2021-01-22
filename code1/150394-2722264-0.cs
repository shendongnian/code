    try
    {
        result = Service.GetResult(param1, param2);
    }
    catch(System.Net.WebException ex)
    {
        Logger.WriteError("Error calling Webservice: ", ex.ToString());
    }
