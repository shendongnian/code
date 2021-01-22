    string userId = String.Empty;
    string password = String.Empty; 
    foreach (var key in Request.Headers.AllKeys)
    {
        if (key == "UserId")
            userId = Request.Headers[key];
        if (password == "Password")
            password = Request.Headers[password];
    }
    if (!String.IsNullOrEmpty(userId) && !String.IsNullOrEmpty(password))
        // attempt login
    else
        // display login page
