     public ActionResult LogIn(int? errorId)
            {
                if (errorId > 0)
                {
                    ViewBag.Error = "UserName Or Password Invalid !";
                }
                return View();
            }
    [Httppost]
    public ActionResult LogIn(FormCollection form)
            {
                string user= form["UserId"];
                string password = form["Password"];
                if (user == "admin" && password == "123")
                {
                   return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("LogIn", "Security", new { @errorId = 1 });
                }
    }
