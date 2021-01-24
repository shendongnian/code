	public static class NameValueCollectionExtensions
	{
		public static RouteValueDictionary ToRouteValueDictionary(this NameValueCollection col)
		{
			var dict = new RouteValueDictionary();
			foreach (var k in col.AllKeys)
			{ 
				dict[k] = col[k];
			}  
			return dict;
		}
	}
