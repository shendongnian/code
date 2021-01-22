    var ctor = typeof(HttpWebRequest).GetConstructor(
		BindingFlags.NonPublic | BindingFlags.Instance, 
		null, 
		new Type[] { typeof(Uri), typeof(ServicePoint) }, 
		null);
	var req = (WebRequest)ctor.Invoke(new object[] { new Uri("ftp://user:pass@host/test.txt"), null });
	req.Proxy = new WebProxy("myproxy", 8080);
	req.Method = WebRequestMethods.Http.Put;
	
	using (var inStream = req.GetRequestStream())
	{
		var buffer = Encoding.ASCII.GetBytes("test upload");
		inStream.Write(buffer, 0, buffer.Length);
	}
	
	using (req.GetResponse())
	{
	}
