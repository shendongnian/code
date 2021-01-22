    var user = _dataContext.Users.SingleOrDefault(p =>
                      p.Name == collection["Username"]
                      && p.Password == collection["Password"]);
    if(user != null)
    {
        // Go on...
        return RedirectToAction("Login");
    }
    else
    {
        // Login Faild
        return View();
