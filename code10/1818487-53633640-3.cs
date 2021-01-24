	public ActionResult StudentLookup(string query)
	{
		var students = repository.Students.Select(m => new StudentViewModel
		{
			Id = m.Id,
			Name = m.Name,
			Surname = m.Surname
		})
		//if "query" is null, get all records
		.Where(m => string.IsNullOrEmpty(query) || m.Name.StartsWith(query)) 
		.OrderBy(m => m.Name);
		return Json(students, JsonRequestBehavior.AllowGet);
	}
