    public ActionResult Create()
    {
        var Sections = _context.Sections.ToList();
        var Customers = _context.Customers.ToList();
        List<SelectListItem> list = new List<SelectListItem>();
        foreach (var item in Customers)
        {
            list.Add(new SelectListItem { Text = item.Customer_Name, Value = item.Customer_Id.ToString() });
            ViewBag.Customers = list;
        }
        List<SelectListItem> list1 = new List<SelectListItem>();
            foreach (var item in Sections)
            {
                list1.Add(new SelectListItem { Text = item.Section_Name, Value = item.Section_Id.ToString() });
                ViewBag.Sections = list1;
            }
            return View();
        }
