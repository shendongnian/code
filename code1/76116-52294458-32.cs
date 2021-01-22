	// simplifies access to anonymous properties
	public static class AnonymousTypeExtensions
	{
		// makes properties of object accessible 
		private static IDictionary AccessProperties(this object o)
		{
			Type type = o?.GetType();
			var properties = type?.GetProperties()
			?.Select(n => n.Name)
			?.ToDictionary(k => k, k => type.GetProperty(k).GetValue(o, null));
			return properties;
		}
		// returns specific property, i.e. x.AccessProperty(propertyName)
		// requires prior usage of AccessListItems and selection of one element, because object
		// needs to be a IDictionary<string, object>
		public static object AccessProperty(this object o, string propertyName)
		{
			return ((System.Collections.Generic.IDictionary<string, object>)o)?[propertyName];
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
