    public static SessionHandler GetInstance()
        {
            if (HttpContext.Current.Session["SessionHandler"] == null)
            {
                HttpContext.Current.Session["SessionHandler"] = new SessionHandler();
            }
            return (SessionHandler)HttpContext.Current.Session["SessionHandler"];
        }
