	public static class AnonymousTypeExtensions
	{
		// makes properties of object accessible 
		public static IDictionary UnanonymizeProperties(this object obj)
		{
			Type type = obj?.GetType();
			var properties = type?.GetProperties()
			?.Select(n => n.Name)
			?.ToDictionary(k => k, k => type.GetProperty(k).GetValue(obj, null));
			return properties;
		}
	
		// returns specific property, i.e. obj.GetProp(propertyName)
		// requires prior usage of AccessListItems and selection of one element, because
		// object needs to be a IDictionary<string, object>
		public static object GetProp(this object obj, string propertyName)
		{
		   return ((System.Collections.Generic.IDictionary<string, object>)obj)?[propertyName];
		}
	
		// converts object list into list of properties that meet the filterCriteria
		public static List<IDictionary> UnanonymizeListItems(this List<object> objectList, 
						Func<IDictionary<string, object>, bool> filterCriteria=default)
		{
			var accessibleList = new List<IDictionary>();
			foreach (object obj in objectList)
			{
				var props = obj.UnanonymizeProperties();
				if (filterCriteria == default
				   || filterCriteria((IDictionary<string, object>)props) == true)
				{ accessibleList.Add(props); }
			}
			return accessibleList;
		}
	}
