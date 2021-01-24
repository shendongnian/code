    void Main()
    {
    	string input = string.Empty;	
    	var list = new List<Pupils>();
    	var regex = new Regex(@"(?<name>[a-zA-Z\s]+)\s+(?<altitude>[0-9]+)",RegexOptions.Compiled);
    	while((input = Console.ReadLine()) != "q")
    	{
    		var matches = regex.Match(input.Trim());
    		 list.Add(new Pupils
    		{ 
    			Name = matches.Groups["name"].Value, 
    			Altitude = int.Parse(matches.Groups["altitude"].Value)
    		});
    	}
    	
    	var maxAltitude = list.Max(x=>x.Altitude);
    	
    	var result = list.Where(x=>x.Altitude.Equals(maxAltitude)).Select(x=>x.Name);
    	
    	Console.WriteLine($"Max Altitude :{maxAltitude}");
    	foreach(var item in result)
    	{
    		Console.WriteLine(item);
    	}
    	
    }
    
    public class Pupils
    {
    	public string Name {get;set;}
    	public int Altitude {get;set;}
    }
