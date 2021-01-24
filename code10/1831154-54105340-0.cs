        private readonly LogEntities _db = new LogEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Log model)
        {
            if (ModelState.IsValid)
            {
                var existingLog = _db.UserActivityLogs.Where(x => x.ID == model.ID).FirstOrDefault();
                if (existingLog == null)   //Create Case
                {
                    _db.UserActivityLogs.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
                else                      //Update Case
                {
                    _db.UserActivityLogs.Attach(model);
                    //Check for each property and set the IsModified flag to true only for updated records
                    if (model.UserName != existingLog.UserName)
                    {
                        _db.Entry(model).Propert(x=> x.UserName).IsModified = true;
                    }
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
