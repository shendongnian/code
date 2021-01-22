    public string user_Name
    {
        get
        {
            string x = Page.User.Identity.Name;
    
            x = x.Replace("YOURDOMAIN\\", "");
    
            return x;
        }
    }
