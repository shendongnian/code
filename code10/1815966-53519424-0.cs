    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var jsonString = @"{'prime':'Af//////////////////////////////////////////////////////////////////////////////////////',
            'a':'Af/////////////////////////////////////////////////////////////////////////////////////8',
            'b':'AFGVPrlhjhyaH5KaIaC2hUDuotpyW5mzFfO4tImRjvEJ4VYZOVHsfpN7FlLAvTuxvwc1c9+IPSw08e9FH9RrUD8A'}";
    		
    		var dataSet = JsonConvert.DeserializeObject<DataSet>(jsonString);
    		
    		Console.WriteLine(System.Text.Encoding.UTF8.GetString(dataSet.prime));
    		Console.WriteLine(System.Text.Encoding.UTF8.GetString(dataSet.a));
    		Console.WriteLine(System.Text.Encoding.UTF8.GetString(dataSet.b));
    	}
    }
    
    public class DataSet
    {
        public byte[] prime {get;set;}
        public byte[] a {get;set;}
        public byte[] b {get;set;}
    }
