        [HttpGet]
        public ActionResult Index()
        {
            List<Main> main = (List<Main>)TempData["yourData"];
            if (main == null)
            {
                main = new List<Main>();
            }
            return View("Index", main);
        }
        public IActionResult Create(List<Main> main)
        {
            TempData["yourData"] = main;
            return RedirectToAction(nameof(Index));
        }
