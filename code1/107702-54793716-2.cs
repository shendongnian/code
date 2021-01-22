cs
using (var client = new TimeoutWebClient(TimeSpan.FromSeconds(10)))
{
    return await client.DownloadStringTaskAsync(url).ConfigureAwait(false);
}
Class:
cs
using System;
using System.Net;
namespace Utilities
{
	public class TimeoutWebClient : WebClient
	{
		public TimeSpan Timeout { get; set; }
		public TimeoutWebClient(TimeSpan timeout)
		{
			Timeout = timeout;
		}
		protected override WebRequest GetWebRequest(Uri uri)
		{
			var request = base.GetWebRequest(uri);
			if (request == null)
			{
				return null;
			}
			var timeoutInMilliseconds = (int) Timeout.TotalMilliseconds;
			request.Timeout = timeoutInMilliseconds;
			if (request is HttpWebRequest httpWebRequest)
			{
				httpWebRequest.ReadWriteTimeout = timeoutInMilliseconds;
			}
			return request;
		}
	}
}
