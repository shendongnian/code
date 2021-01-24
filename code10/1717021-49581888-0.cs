	public class StatesBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			controllerContext.HttpContext.Request.InputStream.Seek(0, SeekOrigin.Begin);
			string urlEncodedFormData = new StreamReader(controllerContext.HttpContext.Request.InputStream).ReadToEnd();
			var decodedFormKeyValuePairs = urlEncodedFormData
				.Split('&')
				.Select(s => s.Split('='))
				.Where(kv => kv.Length == 2 && !string.IsNullOrEmpty(kv[0]) && !string.IsNullOrEmpty(kv[1]))
				.Select(kv => new { key = HttpUtility.UrlDecode(kv[0]), value = HttpUtility.UrlDecode(kv[1]) });
			var states = new List<State>();
			foreach (var kv in decodedFormKeyValuePairs)
			{
				if (kv.key == "stateName")
				{
					states.Add(new State { Name = kv.value, Cities = new List<City>() });
				}
				else if (kv.key == "cityName")
				{
					states.Last().Cities.Add(new City { Name = kv.value });
				}
				else if (kv.key == "cityPopulation")
				{
					states.Last().Cities.Last().Population = int.Parse(kv.value);
				}
				else
				{
					//key-value form field that can be ignored
				}
			}
			return states;
		}
	}
