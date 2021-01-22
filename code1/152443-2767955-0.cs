    HttpCookie myCookie = new HttpCookie("UserSettings");
    myCookie["Font"] = "Arial";
    myCookie["Color"] = "Blue";
    myCookie.Expires = DateTime.Now.AddDays(1d);
    Response.Cookies.Add(myCookie); //<<<<<<<<<-------------------
