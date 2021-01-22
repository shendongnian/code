    WebClient client = new WebClient();
    Uri ur = new Uri("http://remotehost.do/images/img.jpg");
    client.Credentials = new NetworkCredential("username", "password");
    client.DownloadProgressChanged += WebClientDownloadProgressChanged;
    client.DownloadDataCompleted += WebClientDownloadCompleted;
    client.DownloadFileAsync(ur, @"C:\path\newImage.jpg");
