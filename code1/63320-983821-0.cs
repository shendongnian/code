    HttpCookie cookie = Request.Cookies.Get("fontSize");
    // Check if cookie exists in the current request.
    if (cookie == null)
    {
       Response.Write( "Defaulting to 'small'.");
    }
    else
    {
       Response.Write( Request.Cookies["fontSize"].Value);
    )
