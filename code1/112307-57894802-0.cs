    /// <summary>
    /// Creates the CSV from a generic list.
    /// </summary>;
    /// <typeparam name="T"></typeparam>;
    /// <param name="list">The list.</param>;
    /// <param name="csvNameWithExt">Name of CSV (w/ path) w/ file ext.</param>;
    public static void CreateCSVFromGenericList<T>(List<T> list, string csvCompletePath)
    {
    	if (list == null || list.Count == 0) return;
    
    	//get type from 0th member
    	Type t = list[0].GetType();
    	string newLine = Environment.NewLine;
    
    	if (!Directory.Exists(Path.GetDirectoryName(csvCompletePath))) Directory.CreateDirectory(Path.GetDirectoryName(csvCompletePath));
    
    	using (var sw = new StreamWriter(csvCompletePath))
    	{
    		//make a new instance of the class name we figured out to get its props
    		object o = Activator.CreateInstance(t);
    		//gets all properties
    		PropertyInfo[] props = o.GetType().GetProperties();
    
    		//foreach of the properties in class above, write out properties
    		//this is the header row
    		sw.Write(string.Join(",", props.Select(d => d.Name).ToArray()) + newLine);
    		
    		//this acts as datarow
    		foreach (T item in list)
    		{
    			//this acts as datacolumn
                var row = string.Join(",", props.Select(d => $"\"{item.GetType().GetProperty(d.Name).GetValue(item, null)?.ToString()}\"")
    													.ToArray());
    			sw.Write(row + newLine);
    			
    		}
    	}
    }
