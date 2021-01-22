    public IValidationDictionary Login(string user, string password);
    var user = "bob";
    var validator = Login(user, "password");
    if (validator.IsValid)
        Response.Redirect(GetUserPage(user));
    else
        HandleLoginError();
