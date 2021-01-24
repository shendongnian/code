    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public enum SecuritySerachType
        {
            Company = 1,
            Security,
        }
    	public class State{  
            public Dictionary<SecuritySerachType, List<long>> assets { get; set; }
        }
    	
    	public static void Main()
    	{
    		var state = JsonConvert.DeserializeObject<State>(@"{assets :{""1"":[]}}");
    		Console.WriteLine(state.assets[SecuritySerachType.Company].Count);
    	}
    }
