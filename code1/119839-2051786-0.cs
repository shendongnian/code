    var objects = new List<Object>();
    objects.Add(1);
    objects.Add("string");
    objects.Add("magic");
    objects.Add(2.5);
    
    var magic = (from o in objects
    			 where o is string
    			 	&& ((string)o) == "magic"
    			 select o as string).SingleOrDefault();
    
    if(magic != null) {
    	Console.Write("magic found: {0}", magic);
    }
    else {
        // Do your other logic if nothing was found (loop, etc)
    }
	
