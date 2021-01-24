     // GET: Contracts/Create
            public ActionResult Create()
            {
    
         
           var listOfCustomers = new List<SelectListItem>();
    
            foreach (var item in  _context.Customers.ToList())
            {
                listOfCustomers.Add(new SelectListItem { Text = item.Customer_Name, Value = item.Customer_Id.ToString() });
              
            }
            ViewBag.Customers = listOfCustomers;
    
            var listOfSections = new List<SelectListItem>();
    
                foreach (var item in  _context.Sections.ToList())
                {
                    listOfSections.Add(new SelectListItem { Text = item.Section_Name, Value = item.Section_Id.ToString() });
    
                }
            ViewBag.Sections = listOfSections;
    
                return View();
            }
