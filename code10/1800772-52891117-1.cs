    if (!userList.Exists(y => y.UserName == username) && 
        !userList.Exists(y => y.Password == pass))
    {
        TempData["Message"] = "Wrong username or password.";
        return RedirectToAction("Index");
    }
