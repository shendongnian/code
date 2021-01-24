    // GET: Notice
            public ActionResult Index()
            {
                var model = _context.Notice.Include(i => i.College);
    
                return View(model);
            }
