    string url = Request.RawUrl;
    
    NameValueCollection params = Request.QueryString;
    for (int i=0; i<params.Count; i++)
    {
        if (params[i].GetKey(i).ToLower() == "foo")
        {
            url += string.Concat((i==0 ? "?" : "&"), params[i].GetKey(i), "=", params.Get(i));
        }
    }
    Response.Redirect(url);
