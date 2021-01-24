    public ActionResult Index()
            {
                var charts = (from p in db.pmTA_ProjectCategory
    
                              select new
                              {
                                  id = p.id,
                                  title = p.title,
                                  description = p.description,
    
                              }).ToList()
                     .Select(x => new pmTA_ProjectCategory()
                     {
                         id = x.id,
                         title = x.title,
                         description = x.description,
    
                     });
    
                List<SelectListItem> query = db.pmTA_ProjectCategory.Select(c => new SelectListItem
                { Text = c.title, Value = c.id.ToString() }).ToList();
                ViewBag.proj = query;
    
                return View(charts.ToList());
            }
