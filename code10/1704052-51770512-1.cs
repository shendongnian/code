    public class Program
    {
    	public static void Main()
    	{
    		
    		string[] cities = { "London", "Delhi", "Paris", "New York"};
    		
    		//work with StringBuilder
    		var sbCities = new StringBuilder();
    		foreach (string city in cities) { sbCities.Append(city + ", ");}
    		sbCities.Remove(sbCities.Length-2, 2); // remove last comma and space
    		
    		Console.WriteLine($"sbCities = {sbCities}");
    		Console.WriteLine("Cities  you've visited are " + sbCities.ReplaceLastOccurenceOf("Paris", "Karachi").ReplaceLastOccurenceOf(",", " and"));
    		Console.WriteLine();
    		
    		//now for String
    		string stringCities = string.Join(", ", cities);
    		Console.WriteLine($"stringCities = {stringCities}");
    		Console.WriteLine("Cities  you've visited are " + stringCities.ReplaceLastOccurenceOf("Paris", "Karachi").ReplaceLastOccurenceOf(",", " and"));
    		Console.WriteLine();
    	}
    	
    }
