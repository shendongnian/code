    [HttpGet]
    public ActionResult Lowx()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> LoadDataForDataTable()
    {
       var draw = Request.Form.GetValues("draw").FirstOrDefault();
       var start = Request.Form.GetValues("start").FirstOrDefault();
       var length = Request.Form.GetValues("length").FirstOrDefault();
       ///Find sorting column name and order
       var sortColumnName = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
       var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
       
       int pageSize = length != null ? Convert.ToInt32(length) : 0;
       int skip = start != null ? Convert.ToInt32(start) : 0;
       int recordsTotal = 0;
        var query = db.Infos.
                Include(x => x.Profile).
                Include(x => x.Cars).AsQueryable();
        int recordsTotal = query.Count();
        //Sorting By Individual Column
        if (!(string.IsNullOrEmpty(sortColumnName) && string.IsNullOrEmpty(sortColumnDir)))
        {
           query = query.OrderBy(sortColumnName + " " + sortColumnDir);
        }
        int recordsFiltered = query.Count();
    
        var data = await query.Skip(skip).Take(pageSize).ToListAsync();
        return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
    }
