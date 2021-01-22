    public int CurrentUserId
    {
        get
        {
            int userId = 0;
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split('|')[1]);
            }
            return userId;
        }
    }
    public string CurrentUserName
    {
        get
        {
            string userName = string.Empty;
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                userName = HttpContext.Current.User.Identity.Name.Split('|')[0];
            }
            return userName;
        }
    }
