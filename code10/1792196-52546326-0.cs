    public class Item
    {
    	public int Year { get; set; }
    	public string Name { get; set; }
    	public double Val { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		string json = "[{\"Year\":2000,\"Name\":\"Ala\",\"Val\":0.5},{\"Year\":2001,\"Name\":\"Ola\",\"Val\":0.6},{\"Year\":2004,\"Name\":\"Ela\",\"Val\":0.8}]";
    		List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
    		
    		foreach(var item in items)
    		{
    			Console.WriteLine("Year: {0}; Name: {1}; Val: {2}", item.Year, item.Name, item.Val);
    		}
    	}
    }
