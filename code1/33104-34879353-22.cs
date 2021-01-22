    Uri ur = new Uri("http://remotehost.do/images/img.jpg");
	using (WebClient client = new WebClient()) {
        //client.Credentials = new NetworkCredential("username", "password");
		String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("Username" + ":" + "MyNewPassword"));
		client.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
        client.DownloadProgressChanged += WebClientDownloadProgressChanged;
        client.DownloadDataCompleted += WebClientDownloadCompleted;
        client.DownloadFileAsync(ur, @"C:\path\newImage.jpg");
    }
