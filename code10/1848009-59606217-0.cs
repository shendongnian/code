	public class MetricsController : ApiController
	{
		[Route("metrics")]
		[HttpGet]
		public async Task<HttpResponseMessage> AppMetrics()
		{
			using (MemoryStream ms = new MemoryStream())
			{
				await Metrics.DefaultRegistry.CollectAndExportAsTextAsync(ms);
				ms.Position = 0;
				using (StreamReader sr = new StreamReader(ms))
				{
					var allmetrics = await sr.ReadToEndAsync();
					return new HttpResponseMessage()
					{
						Content = new StringContent(allmetrics, Encoding.UTF8, "text/plain")
					};
				}
			}
		}
	}
