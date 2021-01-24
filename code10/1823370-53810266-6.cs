    public ActionResult Create()
    {
        // disable lazy because of error it creates
        _db.Configuration.LazyLoadingEnabled = false;
        var departmentList = _db.Departments.Select(d => new
         {
            d.DepartmentId,
            DepartmentName = d.DepartmentName + " " + d.SubDepartmentName
         }).OrderBy(a => a.DepartmentId).ToList();
        ViewBag.DepartmentList = new SelectList(departmentList,"DepartmentId","DepartmentName");
        return View();
    }
