    using System;
    using System.Net.Http;
    
    public class Program
    {
    	private static HttpClient client = new HttpClient();
    	
    	public static void Main()
    	{
    		var response = client.GetAsync("https://en.wikipedia.org/w/index.php?title=Albatross&action=edit&action=raw").Result;
    		var rawEditCode = response.Content.ReadAsStringAsync().Result;
    		
    		Console.WriteLine(rawEditCode);
    	}
    }
