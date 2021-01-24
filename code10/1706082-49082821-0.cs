    class Program
    {
    	static void Main(string[] args)
    	{
    		String body = "My Name is: {Name} {LastName}";
    		Model model = new Model();
    		model.Name = "Mohammed";
    		model.LastName = "LastName";
    		String result = ReplaceMethod(body, model);
    	}
    
    	private static string ReplaceMethod(string body, Model model)
    	{
    		// can't name property starting with numbers, 
    		// but they are possible
    		Regex findProperties = new Regex(@"{([a-zA-Z]+[0-9]*)}");
    
    		// order by desc, since I want to replace all substrings correctly
    		// after I replace one part length of string is changed 
    		// and all characters at Right are moved forward or back
    		var res = findProperties.Matches(body)
    			.Cast<Match>()
    			.OrderByDescending(i => i.Index);
    
    		foreach (Match item in res)
    		{
    			// get full substring with pattern "{Name}"
    			var allGroup = item.Groups[0];
    
    			//get first group this is only field name there
    			var foundPropGrRoup = item.Groups[1];
    			var propName = foundPropGrRoup.Value;
    
    			object value = string.Empty;
    
    			try
    			{
    				// use reflection to get property
    				// Note: if you need to use fields use GetField
    				var prop = typeof(Model).GetProperty(propName);
    
    				if (prop != null)
    				{
    					value = prop.GetValue(model, null);
    				}
    			}
    			catch (Exception ex)
    			{
    				//TODO Logging here
    			}
    
    			// remove substring with pattern
    			// use remove instead of replace, since 
    			// you may have several the same string
    			// and insert what required
    			body = body.Remove(allGroup.Index, allGroup.Length)
    				.Insert(allGroup.Index, value.ToString());
    		   
    		}
    
    		return body;
    	}
    
    	public class Model
    	{
    		public string Name { get; set; }
    		public string LastName { get; set; }
    	}
    }
