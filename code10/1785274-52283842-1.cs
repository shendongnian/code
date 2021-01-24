	public ActionResult Result<T>(HttpContext httpContext, IQueryable<T> queryable, string[] columns = null) where T : class, ICommonEntity
	{
		var entity = queryable;
		string searchValue = "123";
		if (!string.IsNullOrEmpty(searchValue))
		{
			entity = entity.Where(_ => _.Column1 == searchValue || _.Column2 == searchValue);
			...
		}
	}
