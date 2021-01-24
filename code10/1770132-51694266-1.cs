    public static string[] GetTXT()
	{	
		using (WebClient client = new WebClient())
		{
			var path = @"C:\local\path\file.txt";
			client.Credentials = new NetworkCredential("log", "pass");
			client.DownloadFile("ftp://ftp.example.com/remote/path/file.txt", path);
		}
		if (File.Exists(path))
		{
			
			return File.ReadAllLines(path);
		}
		//return something	
	}
