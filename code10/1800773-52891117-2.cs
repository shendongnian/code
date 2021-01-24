    var user = userList.SingleOrDefault(y => y.UserName == username);
    if (user != null)
    {
        if (user.Password != null && user.Password.Equals(pass))
        {
            // ok
        }
        else
        {
            TempData["Message"] = "Wrong username or password.";
            return RedirectToAction("Index");
        }
    }
    else
    {
        TempData["Message"] = "Wrong username or password.";
        return RedirectToAction("Index");
    }
