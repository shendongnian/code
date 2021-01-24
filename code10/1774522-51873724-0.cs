    if (Request.Cookies["CookieToDelete"] != null)
    {
       Response.Cookies["CookieToDelete"].Expires = DateTime.Now.AddDays(-1);
       Response.Redirect("SomePage.aspx");
       ...
    }
