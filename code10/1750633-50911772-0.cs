	public static class MyExtensions
	{
		public static List<string> GetAdditionalDatabaseNames<T>(this T userQuery)
		{
			var props = userQuery.GetType().GetProperties();
			var result = new List<string>();
			foreach (var db in props.Where(
                                   w => w.PropertyType.Name == "TypedDataContext").Distinct())
			{
				result.Add(db.Name);
			}
			return result;
		}
	}
