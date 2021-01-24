    public T Deserialize<T>(WebResponse response)
        where T: new() // ensure that any type of T used has a parameterless constructor
    {
        string r = "";
        using (StreamReader sr = new StreamReader(res.GetResponseStream()))
        {
            r = sr.ReadToEnd();                        
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Deserialize<T>(r);
    }
