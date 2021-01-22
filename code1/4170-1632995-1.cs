        var nvc = new NameValueCollection();
        nvc.Add(HttpUtility.ParseQueryString(Request.Url.Query));
        nvc.Remove("foo");
        string url = Request.Url.AbsolutePath;
        for (int i = 0; i < nvc.Count; i++)
            url += string.Concat((i == 0 ? "?" : "&"), nvc.Keys[i], "=", nvc[i]);
        Response.Redirect(url);
    
