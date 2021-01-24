	public static void Mymethod<T>(IEnumerable<T> query)
	{
	    var t = typeof(T);
		int pck = 1234;
	
		var mi = typeof(ExcelExtension);
		var met = mi.GetMethod("ListToExcel");
	
		var Headings = t.GetProperties();
		for(int i=0; i < Headings.Length; ++i)
		{
			var prop = Headings[i];
			if (prop.PropertyType.IsClass)
			{
				var genMet = met.MakeGenericMethod(prop.PropertyType);
				
				var nested = query.Select(p => prop.GetValue(p));
	
				object[] parametersArray = new object[] { pck, nested, i };
				genMet.Invoke(null, parametersArray);
			}
		}
	
	}
	
	
	class ExcelExtension
	{
		public void ListToExcel<T>(int pck, IEnumerable<object> nested, int i)
		{
			
		}
	}
