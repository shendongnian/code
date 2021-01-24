    public T GetSimpleModelFromMultiNode<T>(string model, string alias) where T : ISomeInterface, new()
    {
    	var listeItems = CurrentPage.GetPropertyValue<IEnumerable<IPublishedContent>>(alias);
    	var result = new T();
    	if (!CurrentPage.HasValue(alias)) return result;
    	foreach (var item in listeItems)
    	{
    		result.Id = item.Id.ToString();
    		result.Nom = item.Name;
    	}
    	return result;
    }
    
    public class ISomeInterface
    {
    	public int Id { get; set; }
    	public string Nom { get; set; }
    }
    
    public class RegionModel : ISomeInterface
    {
    	//Your implementation goes here
    }
    
    public class SecteurDActiviteModel : ISomeInterface
    {
    	//Your implementation goes here
    }
