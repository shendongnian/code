    public string UrlForRedirecting
    {
        get
        {
            object urlForRedirecting = ViewState["UrlForRedirecting"];
            if (urlForRedirecting != null)
            {
                return urlForRedirecting as string;
            }
            return string.Empty;
        }
        set
        {
            ViewState["UrlForRedirecting"] = value;
        }
    }
