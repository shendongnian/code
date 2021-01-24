    public static void Main()
	{		
		var cityAttrib1 = new Dictionary<string, string>()
		{
			{ "1", "Capital City"},
			{ "2", "High Population"},
			{ "3", "Good Transportation"}
		};
		
		var cityAttrib2 = new Dictionary<string, string>()
		{
			{ "1", "Not a Capital City"},
			{ "2", "Low Population"},
			{ "3", "Poor Transportation"}
		};
		
		var city1 = new City { CityAttributes = cityAttrib1 };
		var city2 = new City { CityAttributes = cityAttrib2 };
			
		var list = new List<City> { city1, city2 };
		
		var sortedList = list.Select(k => k.CityAttributes.OrderBy(x => x.Value)).ToList();
			
        //Print the sorted output
		foreach(var item in sortedList)
		{
			foreach(KeyValuePair<string, string> entry in item)
			{
					Console.WriteLine(entry.Value);	
			}
			Console.WriteLine(Environment.NewLine);
		}
	}
	
	public class City
	{
    	public Dictionary<string, string> CityAttributes { get; set; }
	}
