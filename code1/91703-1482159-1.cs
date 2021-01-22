    public JsonResult Index()
    {
	var json = new
		{
		sucess	= result.sucess,
		data	= from user in repository.FindAllUsers().AsQueryable()
				select new
				{
					id = user.Id,
					name = user.Name,
					...
				}
		};
	return Json(json);
    }
