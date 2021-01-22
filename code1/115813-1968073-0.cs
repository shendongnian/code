    if(User.Identity.IsAuthenticated)
    {
    Response.Write("Logged in already");
    }
    else
    {
    Response.Write("Please log in");
    }
