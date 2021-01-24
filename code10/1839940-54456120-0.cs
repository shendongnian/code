    // GET: Sections/Create
        public ActionResult Create()
        {
            ViewBag.Instructors = db.Instructors.ToList();
    
            return View();
        }
