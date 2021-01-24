    public ActionResult Index(string search = null, int page = 1)
            {
                ViewBag.search = search;
                var model = _db.Employees
                    .Where(r => search == null || r.Name.StartsWith(search) || r.Name.Contains(search))
                    .Select(r => new EmployeeViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                    }).ToPagedList(page, 10);
                return View(model);
            }
