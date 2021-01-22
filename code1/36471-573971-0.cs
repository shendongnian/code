    HttpCookie myCookie = new HttpCookie("MyTestCookie");
    DateTime now = DateTime.Now;
    
    // Set the cookie value.
    myCookie.Value = now.ToString();
    // Set the cookie expiration date.
    myCookie.Expires = now.AddMinutes(1);
    
    // Add the cookie.
    Response.Cookies.Add(myCookie);
    Response.Write("<p> The cookie has been written.");
