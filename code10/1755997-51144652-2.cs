    using System;
    using AutoFixture;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var fixture = new Fixture();
    		var address = fixture.Create<Address>(); // Create an address filled with junk
    		
    		var json = JsonConvert.SerializeObject(address);
    		
    		Console.WriteLine(json);
    	}
    }
