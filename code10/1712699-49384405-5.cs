	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new CultureFilter(defaultCulture: "fi-FI"));
			filters.Add(new HandleErrorAttribute());
		}
	}
