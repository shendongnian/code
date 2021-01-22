	public static class AnonymousTypeExtensions
	{
		// makes properties of object accessible 
		private static IDictionary AccessProperties(this object obj)
		{
			Type type = obj?.GetType();
			var properties = type?.GetProperties()
			?.Select(n => n.Name)
            ?.ToDictionary(k => k, k => type.GetProperty(k).GetValue(obj, null));
			return properties;
		}
		// returns specific property, i.e. x.AccessProperty(propName)
		// requires prior usage of AccessListItems and selection of one element, because
		// object needs to be a IDictionary<string, object>
		public static object AccessProperty(this object obj, string propName)
		{
		    return ((System.Collections.Generic.IDictionary<string, object>)obj)?[propName];
		}
		
		// converts object list into list of properties that meet the filterCriteria
		// e.g. nodes.AccessListItems(x => (bool)x["Checked"]==false)?.FirstOrDefault()
		public static List<IDictionary> AccessListItems(this List<object> objectList, 
							Func<IDictionary<string, object>, bool> filterCriteria=default)
		{
			var accessibleList = new List<IDictionary>();
			foreach (object obj in objectList)
			{
				var props = obj.AccessProperties();
				if (filterCriteria == default 
                   || filterCriteria((IDictionary<string, object>)props) == true)
                { accessibleList.Add(props); }
			}
			return accessibleList;
		}
	}
