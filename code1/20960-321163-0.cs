	WebClient wc = new WebClient();
	wc.DownloadFile("http://stackoverflow.com/Content/Img/stackoverflow-logo-250.png", "Foo.png");
	FileStream fooStream;
	using (fooStream = new FileStream("foo.png", FileMode.Open))
	{
		try
		{ /*do stuff*/ }
		finally
		{ fooStream.Close(); }
	}
	File.Move("foo.png", "foo2.png");
