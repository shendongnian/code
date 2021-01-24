    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class Program
    {
    		public static JsonSerializer _serializer = new JsonSerializer();
            
    	
    	public static void Main()
    	{
    		JObject o = JObject.Parse(@"{
    			  'Stores': [
    				'Lambton Quay',
    				'Willis Street'
    			  ],
    			  'Manufacturers': [
    				{
    				  'Name': 'Acme Co',
    				  'Products': [
    					{
    					  'Name': 'Anvil',
    					  'Price': 50
    					}
    				  ]
    				},
    				{
    				  'Name': 'Contoso',
    				  'Products': [
    					{
    					  'Name': 'Elbow Grease',
    					  'Price': 99.95
    					},
    					{
    					  'Name': 'Headlight Fluid',
    					  'Price': 4
    					}
    				  ]
    				}
    			  ]
    			}");
    
    		Console.WriteLine("1. Print the key Value");
    		Console.WriteLine(o["Manufacturers"].ToString());
    		Console.WriteLine("--------");
    		Console.WriteLine("2. Iterate and print by keyname - (Key - Value) ");
    		
    			foreach(var m in o){
    				
    				if(m.Key == "Manufacturers")
    				Console.WriteLine(m.ToString());
    			}
    					
    		
    	}
    
    }
