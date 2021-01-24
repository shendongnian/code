	using System;
	using System.Net.Http;
	using System.Threading.Tasks;
	namespace TestApi
	{
		public class MyController : Controller
		{
			private const string ApiUrlString = "https://apiUrl.com";
			private static readonly Uri ApiUri = new Uri(ApiUrlString);
			private static readonly HttpClient RestClient;
			static MyController()
			{
				this.RestClient = new HttpClient{
					BaseAddress = ApiUri
				}
				this.RestClient.DefaultRequestHeaders.Accept.Clear();
				this.RestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				RestClient.DefaultRequestHeaders.TryAddWithoutValidation("APIAccessToken", "token1");
				RestClient.DefaultRequestHeaders.TryAddWithoutValidation("UserToken", "token2");
			}
			public async Task<IActionResult> ApiTest()
			{
				return this.Ok(await this.RestClient.GetStringAsync("somedata/search?text=test"));
			}
		}
	}
