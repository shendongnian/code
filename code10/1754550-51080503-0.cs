    public ActionResult Create()
        {
            return View();
        }
        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Created,Modified")] Movie movie)
        {
            movie.CreatedBy = Util.UserInfo.Username;
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                  db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
