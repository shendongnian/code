    [HtttpGet]
    public ActionResult Create()
    {
        var sections = _context.Sections.ToList();
        var customers = _context.Customers.ToList();
        
        ViewBag.SectionSelectList = new SelectList(sections,"Section_Id","Section_Name");
        ViewBag.CustomerSelectList = new SelectList(customers,"Customer_Id","Customer_Name");
        return View();
     }
