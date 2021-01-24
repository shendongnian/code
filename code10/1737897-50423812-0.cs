        public async Task<IActionResult> Index(int id, 
        [Bind("Urlid,Userid,UrlStr,Title")] Url blog, int Urlid)
        {
            var blogging02Context = _context.Tag.Include(t => t.Blog).Where(t => t.Urlid == Urlid));
            ViewBag.Urlid = Urlid;
            return View(await blogging02Context.ToListAsync());
        }
