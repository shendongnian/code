    public static void Main()
	{
		Console.WriteLine("Hello World");
		
		var myDietFavorites = new Dictionary<string, string>()
		{
			{ "1", "Burger"},
			{ "2", "Fries"},
			{ "3", "Donuts"}
		};
			
		var someClass = new SomeClass { SomeProperty = myDietFavorites };
		var someClass1 = new SomeClass { SomeProperty = myDietFavorites };
			
		var list = new List<SomeClass> { someClass, someClass1 };
		
		var sortedList = list.Select(k => k.SomeProperty.OrderBy(x => x.Value)).ToList();
			
		foreach(var item in sortedList)
		{
			foreach(KeyValuePair<string, string> entry in item)
			{
					Console.WriteLine(entry.Value);	
			}
		}
	}
	
	public class SomeClass
	{
    	public Dictionary<string, string> SomeProperty { get; set; }
	}
