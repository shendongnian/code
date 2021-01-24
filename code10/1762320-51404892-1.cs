    [HttpPost]
    public ActionResult Create(CreateReportViewModel report)
    {
    if (ModelState.IsValid)
    {
        var report = new Report();
        report.Contacts = report.Contacts;
        //save to db
    }
    else
    {
        var model = new CreateReportViewModel();
       //init ContactsList
       model.ContactsList = GetContacts(); //this method retrieves a list from a database table
       return View(model);
    }
       
    }
