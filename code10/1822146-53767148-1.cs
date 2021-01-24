    public IEnumerable<T> GetSimpleModelFromMultiNode<T>(string model, string alias) where T : ISomeInterface, new()
    {
    	var listeItems = CurrentPage.GetPropertyValue<IEnumerable<IPublishedContent>>(alias);	
    	if (!CurrentPage.HasValue(alias)) return Enumerable.Empty<T>();
    	return listeItems.Select(i => new T 
    	{
    		Id = i.Id.ToString(),
    		Nom = i.Name,
    	});
    }
