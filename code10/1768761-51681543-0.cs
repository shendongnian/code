    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Dictionary<int, List<Thing>> prefabs = new Dictionary<int, List<Thing>>();
            // add a few items to the lists
    		prefabs.Add(1, new List<Thing>(){ new Thing("Thing1"), new Thing("Thing1") });
    		prefabs.Add(2, new List<Thing>(){ new Thing("Thing2"), new Thing("Thing2"), new Thing("Thing2") });
		
		    var keys = prefabs.Keys;
            // set everything inactive except the first one
		    foreach(int i in keys){
			    prefabs[i].Skip(1).ToList().ForEach(x => x.active = false);
		    }
		    
            // print out the active state
            foreach(int i in keys){
			    foreach(Thing t in prefabs[i]){
				    Console.WriteLine("prefab " + i + "  active = " + t.active);
			    }
		    }
	    }
	
	    class Thing {
		    public bool active = true;
		    public String name = "";
		
		    public Thing(String name){
			this.name = name;
		    }
	    }
    }
