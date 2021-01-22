    public static IEnumerable<T> ReadCsvFileTextFieldParser<T>(string fileFullPath, string delimiter = ";") where T : new()
    {
    	if (!File.Exists(fileFullPath))
    	{
    		return null;
    	}
    
    	var list = new List<T>();
    	var csvFields = GetAllFieldOfClass<T>();
    	var fieldDict = new Dictionary<int, MemberInfo>();
    
    	using (TextFieldParser parser = new TextFieldParser(fileFullPath))
    	{
    		parser.SetDelimiters(delimiter);
    		
    		bool headerParsed = false;
    	
    		while (!parser.EndOfData)
    		{
    			//Processing row
    			string[] rowFields = parser.ReadFields();
    			if (!headerParsed)
    			{
    				for (int i = 0; i < rowFields.Length; i++)
    				{
    					// First row shall be the header!
    					var csvField = csvFields.Where(f => f.Name == rowFields[i]).FirstOrDefault();
    					if (csvField != null)
    					{
    						fieldDict.Add(i, csvField);
    					}
    				}
    				headerParsed = true;
    			}
    			else
    			{
    				T newObj = new T();
    				for (int i = 0; i < rowFields.Length; i++)
    				{
    					var csvFied = fieldDict[i];
    					var record = rowFields[i];
    
    					if (csvFied is FieldInfo)
    					{
    						((FieldInfo)csvFied).SetValue(newObj, record);
    					}
    					else if (csvFied is PropertyInfo)
    					{
    						var pi = (PropertyInfo)csvFied;
    						pi.SetValue(newObj, Convert.ChangeType(record, pi.PropertyType), null);
    					}
    					else
    					{
    						throw new Exception("Unhandled case.");
    					}
    				}
    				if (newObj != null)
    				{
    					list.Add(newObj);
    				}
    			}
    		}
    	}
    	return list;
    }
    
    public static IEnumerable<MemberInfo> GetAllFieldOfClass<T>()
    {
    	return
    		from mi in typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
    		where new[] { MemberTypes.Field, MemberTypes.Property }.Contains(mi.MemberType)
    		let orderAttr = (ColumnOrderAttribute)Attribute.GetCustomAttribute(mi, typeof(ColumnOrderAttribute))
    		orderby orderAttr == null ? int.MaxValue : orderAttr.Order, mi.Name
    		select mi;            
    }
        
