    System.Net.WebClient wc;
    
    RootObject ro = null;
    try
    {
        wc = new System.Net.WebClient();
        string resp = wc.DownloadString("https://restcountries.eu/rest/v2/alpha/" + Row.Code.ToString());
    
        JavaScriptSerializer js = new JavaScriptSerializer();
    
        ro = js.Deserialize<RootObject>(resp);
    }
    catch (Exception e)
    {
        // Log your error
    }
    
    if (ro?.Region != null)
    {
        Row.Region = ro.Region;
        Row.SubRegion = ro.Subregion;
    }
