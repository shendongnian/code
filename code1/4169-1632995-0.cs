     var nvc = new NameValueCollection();
    
     nvc.Add(HttpUtility.ParseQueryString(Request.Url.Query));
    
     nvc.Remove("foo");
    
     Response.Redirect(Request.Url.AbsolutePath + "?" + nvc); 
