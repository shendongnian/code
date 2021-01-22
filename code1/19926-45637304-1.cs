    using System.Net;
    // ...
	using (WebClient client = new WebClient()) {
        Uri ur = new Uri("http://remotehost.do/images/img.jpg");
        //client.Credentials = new NetworkCredential("username", "password");
		String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("Username" + ":" + "MyNewPassword"));
		client.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
        client.DownloadProgressChanged += (o, e) =>
        {
            Console.WriteLine($"Download status: {e.ProgressPercentage}%.");
            // updating the UI
    		Dispatcher.Invoke(() => {
			    progressBar.Value = e.ProgressPercentage;
		    });
        };
        client.DownloadDataCompleted += (o, e) => 
        {
            Console.WriteLine("Download finished!");
        };
        client.DownloadFileAsync(ur, @"C:\path\newImage.jpg");
    }
