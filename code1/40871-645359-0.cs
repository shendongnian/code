    public void DeleteCookie(string cookieName)
    {
        if (Request.Cookies[cookieName] != null)
        {
            HttpCookie myCookie = new HttpCookie(cookieName);
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }
    }
