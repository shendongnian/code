    using System.Net;
    ...
    StringBuilder url = new StringBuilder("http://example.com?p=");
	try
	{
		for (int i = 1; i < Int32.MaxValue; i++)
		{
			url.Append("0");
			HttpWebRequest request = HttpWebRequest.CreateHttp(url.ToString());
		}
	}
	catch (Exception ex)
	{
		Console.Out.WriteLine("Error occurred at url length: " + url.Length);
		Console.Out.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
		return;
	}
    Console.Out.WriteLine("Completed without error!");
