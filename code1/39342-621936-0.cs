	public static IQueryable<T> Filter<T>(this IQueryable<T> query, Dictionary<string, string> dictionary)
	{
		Type t = typeof(T);
		StringBuilder sb = new StringBuilder();
	      	PropertyInfo[] properties = t.GetProperties();
	      	foreach(string key in dictionary.Keys)
	      	{
	      		PropertyInfo property = properties.Where(p => p.Name == key).SingleOrDefault();
	      		if(property != null)
	      		{
	      			if (sb.Length > 0) sb.Append(" && ");
	      			
	      			string value = dictionary[key];
	      			
	      			sb.Append(string.Format(@"{0}.ToString().Contains(""{1}"")", key, value));
	      		}
	      	}
	      	
	      	if (sb.Length > 0)
			return query.Where(sb.ToString());
		else
	        	return query;
	}
