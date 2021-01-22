    public JsonResult Index()
    {
    	var json = new
    		{
    		sucess	= true,
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
