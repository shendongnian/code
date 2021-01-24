    public ActionResult Index()
        {
            var users = db.Users.Select().Where(u => u.Users1).ToList();
            return View(users);
        }
