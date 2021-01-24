    private int pageLength = 10;
        public ActionResult List(int? page)
            { 
                var currentPage = page ?? 0;
                return View(db.Classes
                              .Skip(currentPage * pageLength)
                              .Take(pageLength)
                              .ToList());
            }
