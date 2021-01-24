    public class RootObject
    {
    	public string Description { get; set; }
    	public string ProviderID { get; set; }
    	public string Route { get; set; }
    }
	var items = JsonConvert.DeserializeObject<RootObject[]>(response);
	var routeNumbers = items.Select(i => i.Route).ToList();
