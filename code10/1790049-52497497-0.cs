        public ActionResult Query(id)
        {
            var cat = _context.Categories
                 .Include(c=>c.Subcat)
                 .FirstOrDefault(c=>c.Id == id)
            return View(cat);
        }
