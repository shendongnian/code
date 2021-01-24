    [HttpPost]
    public ActionResult About(TestData testdata) //No need for UserLog model here
    {
    
    
        if (ModelState.IsValid)
        {
            // insert into Userlog table
            var inputUser = ConfigurationManager.AppSettings["INPUT_USER"].ToString().ToLower();
            var usr = _db.UserLogs.SingleOrDefault(u => u.ID == id);
            string date = DateTime.Now;
            usr.UserName = inputUser;
            usr.ModifiedFiledName = PhoneNumber;
            usr.Date = date;
    
            _db.UserLogs.Add(usr);
            _db.Entry(usr).State = EntityState.Added;
    
            // update TestData table
            _db.TestDatas.Add(testdata);
            _db.Entry(testdata).State = EntityState.Added;
    
            //Save both tables
            _db.SaveChanges();
        }
        return RedirectToAction("About");
    }
