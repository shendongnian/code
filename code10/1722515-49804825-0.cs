    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"
    		{  
    			 '01':'One',
     			 '02':'Two',
      			 '03':'Three',
     			 '04':'Four',
     			 '05':'Five',
     			 '06':'Six',
      			 '07':'Seven',
     			 '08':'Eight',
      			 '09':'Nine',
       			 '10':'Ten'
    		}";
    		
    		JObject o = JObject.Parse(json);
    		NumberObject zero = new NumberObject("00", "zero");
    		List<NumberObject> list = new List<NumberObject>();
    
    		foreach (JProperty p in o.Properties())
    		{
    			NumberObject num = new NumberObject(p.Name, (string)p.Value);
    			list.Add(num);
    		}
    		
    		// now list can be used as your data source as it is of type List<NumberObject>
    	}
    }
    
    public class NumberObject 
    {
    	public string Name {get; set;}
    	public string Value {get; set;}
    	
    	public NumberObject(string numName, string numValue)
        {
          Name = numName;
          Value = numValue;
        }
    }
