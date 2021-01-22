        var qs = HttpUtility.ParseQueryString(Request.Url.Query);
        qs.Remove("foo"); 
     
        string url = "~/Default.aspx"; 
        if (qs.Count > 0)
           url = url + "?" + qs.ToString();
     
        Response.Redirect(url); 
