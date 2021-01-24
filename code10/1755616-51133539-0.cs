    public static IEnumerable<MyData> PopulateGrid(string file, string id)
    {
    	var xml = XElement.Load(file);
    	var result = xml.Element("database").Elements("object")
    	.SelectMany(o => o.Element("attributes").Elements("attribute"))
    	.Where(x => (string)x.Attribute("id") == id)
    	.Select(a => new MyData
    	{
    		Id = (string)a.Attribute("id"),
    		Name = (string)a.Attribute("name"),
    		Description = (string)a.Attribute("description")
    	});
    
    	return result;
    }
    
    public class MyData
    {
    	public string Id { get; set; }
    	public string Name { get; set; }
    	public string Description { get; set; }
    }
