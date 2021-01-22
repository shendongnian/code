	// simplifies access to anonymous properties
	public static class AnonymousTypeExtensions
	{
		// make properties of object accessible 
		// eg. x.AccessProperties() or x.AccessProperties()["PropName"]
		public static IDictionary AccessProperties(this object o, string propertyName=null)
		{
			Type type = o?.GetType();
			var properties = type?.GetProperties()
			?.Select(n => n.Name)
			?.ToDictionary(k => k, k => type.GetProperty(k).GetValue(o, null));
			return properties;
		}
		// returns specific property, i.e. x.AccessProperty(propertyName)
		public static object AccessProperty(this object o, string propertyName)
		{
			return o?.AccessProperties()?[propertyName];
		}
		
		// converts object list into list of properties
		public static List<IDictionary> AccessListItems(this List<object> objectList)
		{
			var accessibleList = new List<IDictionary>();
			foreach (object obj in objectList)
			{
				accessibleList.Add(obj.AccessProperties());
			}
			return accessibleList;
		}	
	}
