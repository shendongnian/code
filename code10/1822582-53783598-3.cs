		public static async Task Download()
		{
			HttpClientHelper clientHelper = new HttpClientHelper();
			List<HttpResult> httpResults = new List<HttpResult>();
			var urls = new[] {
				"https://github.com/naudio/NAudio",
				"https://twitter.com/mark_heath",
				"https://github.com/markheath/azure-functions-links",
				"https://pluralsight.com/authors/mark-heath",
				"https://github.com/markheath/advent-of-code-js",
				"https://stackoverflow.com/users/7532/mark-heath",
				"https://mvp.microsoft.com/en-us/mvp/Mark%20%20Heath-5002551",
				"https://github.com/markheath/func-todo-backend",
				"https://github.com/markheath/typescript-tetris",};
			foreach (var url in urls)
			{
				HttpResult httpResult = clientHelper.GetStringAsync(url);
				httpResults.Add(httpResult);
				if (httpResult.HasError)
				{
					Console.WriteLine($"Error occurred: '{httpResult.Error}' on characters from {url}");
				}
				else
				{
					Console.WriteLine($"retrieved {httpResult.Result.Length} characters from {url}");
				}
				await Task.Delay(5000);
			}
		}
	public class HttpClientHelper
	{
		public async Task<HttpResult> GetStringAsync(string url)
		{
			HttpResult httpResult = new HttpResult
			{
				URL = url
			};
			try
			{
				HttpClient client = new HttpClient();
				httpResult.Result = await client.GetStringAsync(url);
			}
			catch (Exception e)
			{
				//todo:handel Exception
				httpResult.HasError = true;
				httpResult.Error = e.Message + Environment.NewLine + e.InnerException?.Message;
			}
			return httpResult;
		}
	}
	public class HttpResult
	{
		public string URL { get; set; }
		public bool HasError { get; set; }
		public string Error { get; set; }
		public string Result { get; set; }
	}
