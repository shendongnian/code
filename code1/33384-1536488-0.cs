    // reflect to readonly property
    PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
    
    // make collection editable
    isreadonly.SetValue(this.Request.QueryString, false, null);
    
    // remove
    this.Request.QueryString.Remove("foo");
    
    // modify
    this.Request.QueryString.Set("bar", "123");
    
    // make collection readonly again
    isreadonly.SetValue(this.Request.QueryString, true, null);
