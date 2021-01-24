    public void SomeGenericMethod<T>(T model) where T : class
    {
    	if (model == null) return null;
    	var propId = model.GetType().GetProperty("id");
    	var propName = model.GetType().GetProperty("name");
    	if (propId == null || propName == null)
    		return;
    
   
    	return new IdNameVM()
    	{
    		Id = model.Id,
    		Name = model.Name
    	};
    }
