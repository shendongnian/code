    public ActionResult Index(int? page)
        {
            if (!validateInt(page.ToString()))
                page = 0;
            page = page - 1;
            if (page < 0)
                page = 0;
            const int pagesize = 9;
            IQueryable<material> myMaterial = material.All().Where(x => x.category == "Granite").OrderBy(x => x.id);
            var mycount = material.All().Where(x => x.category == "Granite").OrderBy(x => x.id).Count();
            
            ViewData["numpages"] = mycount / 9;
            ViewData["curpage"] = page;
            return View(new PagedList<material>(myMaterial, page ?? 0, pagesize));
        }
