    public ActionResult Index(List<InterestViewModel> filterList)
	{		
        //Generate a list of filtered ids
		var filterIds = filterList.Where(f => f.IsSelected).Select(f => f.Id);
        //Find contacts
        var filteredContacts = db.Contacts
        .Where(c => c.Interests.Any(i => filterIds.Contains(i.Id)))
        .Include(c => c.Interests)
        .ToList();
		return View(filteredContacts);   
		//return View(db.Contacts.ToList());
	}
