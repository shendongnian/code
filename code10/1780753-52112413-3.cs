    public PartialViewResult GetItem(int id)
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
                var partailResult = charts.Where(x => x.id == id).ToList();
                return PartialView("_GetItem", partailResult);
            }
