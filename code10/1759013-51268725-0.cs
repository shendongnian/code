	public class Item
	{
        // jsonignore is an attribute to ... ignore this in json
		[JsonIgnore]
    	public string Name { get; set; }
    	public string Prop1 { get; set; }
	}
	
	public static void Main()
	{
		var items = new List<Item>
		{
    		new Item { Name = "a", Prop1 = "123" },
    		new Item { Name = "b", Prop1 = "456" },
    		new Item { Name = "c", Prop1 = "789" }
		};
		
        // we use a Dictionary as Amy propose in comment
		var obj = items.ToDictionary(x=> x.Name, x => x);
		var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings 
    	{ 
            // we need this to use camel case
        	ContractResolver = new CamelCasePropertyNamesContractResolver() 
    	});
		
		Console.WriteLine(json);
	}
