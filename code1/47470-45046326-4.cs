	using System;
	using System.Web;
	namespace Util
	{
		public static class IP
		{
			public static string GetIPAddress()
			{
				return GetIPAddress(new HttpRequestWrapper(HttpContext.Current.Request));
			}
			internal static string GetIPAddress(HttpRequestBase request)
			{
				// handle standardized 'Forwarded' header
				string forwarded = request.Headers["Forwarded"];
				if (!String.IsNullOrEmpty(forwarded))
				{
					foreach (string segment in forwarded.Split(',')[0].Split(';'))
					{
						string[] pair = segment.Trim().Split('=');
						if (pair.Length == 2 && pair[0].Equals("for", StringComparison.OrdinalIgnoreCase))
						{
							string ip = pair[1].Trim('"');
							// IPv6 addresses are always enclosed in square brackets
							int left = ip.IndexOf('['), right = ip.IndexOf(']');
							if (left == 0 && right > 0)
							{
								return ip.Substring(1, right - 1);
							}
							// strip port of IPv4 addresses
							int colon = ip.IndexOf(':');
							if (colon != -1)
							{
								return ip.Substring(0, colon);
							}
							// this will return IPv4, "unknown", and obfuscated addresses
							return ip;
						}
					}
				}
				// handle non-standardized 'X-Forwarded-For' header
				string xForwardedFor = request.Headers["X-Forwarded-For"];
				if (!String.IsNullOrEmpty(xForwardedFor))
				{
					return xForwardedFor.Split(',')[0];
				}
				return request.UserHostAddress;
			}
		}
	}
