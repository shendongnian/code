    NameValueCollection oQuery = Request.QueryString;
    oQuery = (NameValueCollection)Request.GetType().GetField("_queryString",BindingFlags.NonPublic | BindingFlags.Instance).GetValue(Request);
    PropertyInfo oReadable = oQuery .GetType().GetProperty("IsReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
    oReadable.SetValue(oQuery, false, null);
    oQuery["foo"] = "bar";
    oReadable.SetValue(oQuery, true, null); 
