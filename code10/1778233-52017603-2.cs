    public interface IDatabase
    {
    	int? GetPopulation(string name);
    	Capitol GetCapitol(string name);
    }
    
    public class Capitol
    { 
    	public string CapitolName { get; set; }
    	public string Country { get; set; }
    	public int? Population { get; set; }
    }
    
    public class SingleTOnDatabase : IDatabase
    {
    
    	private System.Collections.Generic.List<Capitol> capitols;
    
    	private SingleTOnDatabase()
    	{
    		Console.WriteLine("Initializing database");
    
    		int pop;
    		capitols = (from batch in File.ReadAllLines("Capitols.txt").Batch(3)
    					   let bArr = batch.ToArray()
                           where bArr.Length == 3
    					   select new Capitol
    					   {
    						   CapitolName = bArr[0].Trim(),
    						   Country = bArr[1].Trim(),
    						   Population = int.TryParse(bArr[2], out pop) ? pop : (int?)null
    					   }).ToList();
    	}
    
    
    	public int? GetPopulation(string name)
    	{
            var capitol = GetCapitol(name);
    		return capitol?.Population;
    	}
    	
    	public Capitol GetCapitol(string name)
    	{
    		return capitols.SingleOrDefault(c => c.CapitolName.ToLower().Trim() == name.ToLower().Trim());
    	}
    	
    	private static Lazy<SingleTOnDatabase> instance = new Lazy<SingleTOnDatabase>(() => new SingleTOnDatabase());
    	public static SingleTOnDatabase Instance => instance.Value;
    
    }
    public class Program
    {
    	static void Main(string[] args)
    	{
    
    		var db = SingleTOnDatabase.Instance;
    		var city = "Den Haag";
    		var Country = "Nederland";
    		Console.WriteLine($"{Country} with {city} has population of: {db.GetPopulation(city)}");
    
            var city2 = "Tokyo";
    		var cap = db.GetCapitol(city2);
    		if (cap == null)
    		{
    			Console.WriteLine($"Unknown city [{city2}].");
    		}
    		else
    		{
    			Console.WriteLine($"{cap.CapitolName} is the capital of {cap.Country} and has population of: {cap.Population}");
    		}
    		
    		Console.Read();
    	}
    }
