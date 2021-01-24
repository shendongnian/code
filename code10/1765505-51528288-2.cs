    using System;
    using System.Collections.Specialized;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		var str = @"Invoice #:
    					1267
    					
    					<br>
    					
    					Date:
    					4/16/2018 10:44:00 AM
    					
    					<br>
    					
    					PO #:
    					
    					<br>
    					
    					Reference:
    					
    					<br>
    					
    					Countermen:
    					A/A";
            
            //Array containing "raw string data"
    		var raw = str.Split(new[]{"<br>"}, StringSplitOptions.RemoveEmptyEntries);
            //Just using a simple NVC, opt for something else based on your needs		
    		var kvp = new NameValueCollection();
            //Go through the raw array we created earlier and
            // add the key/value pairs to our NameValueCollection, kvp
    		Array.ForEach(raw, s =>
    		{
    			//Because of date/time, we'll restrict colon to first occurrence
    			var data = s.Split(new [] {":"}, 2, StringSplitOptions.None);
    			kvp.Add(data[0].Trim(), data[1].Trim());
    		});
    		
            /*
             * At this point, we have our "parsed" data in
             * key/value pairs, kvp and can use it as needed
             *
             */
            // We can loop through the kvp and simply display
    		foreach(string k in kvp.Keys){
    			Console.WriteLine("{0} = {1}", k, kvp[k]);
    		}
            // We can assign values to variables we create
            var invNum = kvp["Invoice #"];
    	}
    }
