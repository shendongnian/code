    [HttpPost]
    public ActionResult Create(CreateReportViewModel reportModel)
	{
		if (ModelState.IsValid)
		{
			var report = new Report();
			report.Contacts = reportModel.Contacts;
			//save to db
		}
		else
		{
		   //init ContactsList
		   reportModel.ContactsList = GetContacts(); //this method retrieves a list from a database table
		   return View(reportModel);
		}
	
	}
