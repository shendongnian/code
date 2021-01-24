    RootObject ro = null;
    try
    {
        string resp = wc.DownloadString("https://restcountries.eu/rest/v2/alpha/" + Row.Code.ToString());
        JavaScriptSerializer js = new JavaScriptSerializer();
        ro = js.Deserialize<RootObject>(resp);
    }
    catch (Exception e)
    { }
    if (ro?.Region != null)
    {
        Row.Region = ro.Region;
        Row.SubRegion = ro.Subregion;
    }
