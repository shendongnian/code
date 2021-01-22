	using Newtonsoft.Json;
	using System.Net.Http;
	namespace Base
	{
		public class ApiConsumer<T>
		{
			public T data;
			private string url;
			public CalendarApiConsumer(string url)
			{
				this.url = url;
				this.data = getItems();
			}
			private T getItems()
			{
				T result = default(T);
				HttpClient client = new HttpClient();
                // This allows for debugging possible JSON issues
				var settings = new JsonSerializerSettings
				{
					Error = (sender, args) =>
					{
						if (System.Diagnostics.Debugger.IsAttached)
						{
							System.Diagnostics.Debugger.Break();
						}
					}
				};
				using (HttpResponseMessage response = client.GetAsync(this.url).Result)
				{
					if (response.IsSuccessStatusCode)
					{
						result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result, settings);
					}
				}
				return result;
			}
		}
	}
