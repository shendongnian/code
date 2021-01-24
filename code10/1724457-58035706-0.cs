`csharp
	public static void HeaderNameValueEncode(string headerName, string headerValue, out string encodedHeaderName, out string encodedHeaderValue)
	{
		if (string.IsNullOrEmpty(headerName))
		{
			encodedHeaderName = headerName;
		}
		else
		{
			var sb = new StringBuilder();
			headerName.All(ch => { if ((ch == 9 || ch >= 32) && ch != 127) sb.Append(ch); return true; });
			encodedHeaderName = sb.ToString();
		}
		if (string.IsNullOrEmpty(headerValue))
		{
			encodedHeaderValue = headerValue;
		}
		else
		{
			var sb = new StringBuilder();
			headerValue.All(ch => { if ((ch == 9 || ch >= 32) && ch != 127) sb.Append(ch); return true; });
			encodedHeaderValue = sb.ToString();
		}
	}	
`
or, if you prefer to convert only one string:
`csharp
	public static string HeaderNameOrValueEncode(string headerString)
	{
		if (string.IsNullOrEmpty(headerString))
		{
			return headerString;
		}
		else
		{
			var sb = new StringBuilder();
			headerString.All(ch => { if ((ch == 9 || ch >= 32) && ch != 127) sb.Append(ch); return true; });
			return sb.ToString();
		}
	}	
`
