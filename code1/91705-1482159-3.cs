    public JsonResult Index()
    {
    	var json = new
    	{
    	    success = result.success,
    	    data = from user in repository.FindAllUsers().AsQueryable()
                   select new
                   {
                       id = user.Id,
                       name = user.Name,
                       ...
                   }
        };
    	return Json(json);
    }
