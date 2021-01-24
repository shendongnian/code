    public T GetSimpleModelFromMultiNode<T>(string model, string alias) where T : ISomeInterface, new()
    {
    	var listeItem = CurrentPage.GetPropertyValue<IEnumerable<IPublishedContent>>(alias).FirstOrDefault();	
    	if (!CurrentPage.HasValue(alias)) return new T();
    	
    	if (listeItem == null)
    	{
    		return new T();
    	}
    	
    	return new T
    	{
    		Id = listeItem.Id.ToString(),
    		Nom = item.Name
    	};
    }
