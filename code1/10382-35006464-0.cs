        [Route("~/")]
        public ActionResult Index(int? page)
        {
            var query = from p in db.Posts orderby p.post_date descending select p;
            var pageNumber = page ?? 1;
            ViewData["Posts"] = query.ToPagedList(pageNumber, 7);         
            return View();
        }
        [Route("about")]
        public ActionResult About()
        {
            return View();
        }
        [Route("contact")]
        public ActionResult Contact()
        {
            return View();
        }
        [Route("team")]
        public ActionResult Team()
        {
            return View();
        }
        [Route("services")]
        public ActionResult Services()
        {
            return View();
        }
