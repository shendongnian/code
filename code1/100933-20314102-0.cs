    if (Request.Cookies["TownID"] != null)
    {
           HttpCookie myCookie = Request.Cookies["TownID"];
           myCookie.Expires = DateTime.Now.AddDays(-1d);
           Response.Cookies.Add(myCookie);
    }
