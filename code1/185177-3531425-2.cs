    public bool Visible1
    {
        get 
        {
            bool b;
            return Boolean.TryParse(HttpContext.Current.Request["visible"], out b) && b;
        }
    }
    public bool Visible2
    {
        get
        {
            bool b;
            return Boolean.TryParse(HttpContext.Current.Request["visible"], out b) ? b : false;
        }
    }
    public bool Visible3
    {
        get
        {
            bool b;
            Boolean.TryParse(HttpContext.Current.Request["visible"], out b);
            return b;
        }
    }
