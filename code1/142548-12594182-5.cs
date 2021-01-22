    //  START CHANGE
    // this next check seems unlikely
    if(! (HttpContext.Current.Session  == null))
    {
    //  pass HttpContext.Current.Session["APP_Path"].ToString() as a parameter 
    if (!(String.IsNullOrEmpty(HttpContext.Current.Session["APP_Path"].ToString())))// set in Global.asax.cs Start_Session
        exporter.Arguments.Add(exporter.Arguments.Count, HttpContext.Current.Session["APP_Path"].ToString()); // to last parameter position
    else
        exporter.Arguments.Add(exporter.Arguments.Count, String.Empty); // or nothing to last parameter position
    //   end change
    }
