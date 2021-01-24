    if (Request.Cookies["test"] != null)
    {
        HttpCookie myCookie = new HttpCookie("test");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(myCookie);
    }
