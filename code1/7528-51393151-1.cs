    public static class HttpClientExtensions
	{
		public static async Task<long> GetContentSizeAsync(this System.Net.Http.HttpClient client, string url)
		{
			using (var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url))
			{
				// In order to keep the response as small as possible, set the requested byte range to [0,0] (i.e., only the first byte)
				request.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(from: 0, to: 0);
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					if (response.StatusCode != System.Net.HttpStatusCode.PartialContent) 
						throw new System.Net.WebException($"expected partial content response ({System.Net.HttpStatusCode.PartialContent}), instead received: {response.StatusCode}");
					
					var contentRange = response.Content.Headers.GetValues(@"Content-Range").Single();
					var lengthString = System.Text.RegularExpressions.Regex.Match(contentRange, @"(?<=^bytes\s[0-9]+\-[0-9]+/)[0-9]+$").Value;
					return long.Parse(lengthString);
				}
			}
		}
	}
 
