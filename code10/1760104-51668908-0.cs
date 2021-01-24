     public JsonResult Search()
    {
        List<User> users;
        users = db.Users.ToList();
        return JSon(users,JsonRequestBehavior.AllowGet);
    }
