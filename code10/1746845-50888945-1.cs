I think it's a problem with a Keep-Alive header. You can capture the http request and check this value. A value of true will try to mantain a connection opened. Not all proxies are compatible with this header.
Try to use two diferent WebClient instances and dispose them before use the next one. Or force the header to false.
    WebClient webClient = new WebClient();
    webClient.QueryString.Add("downloadId", id);
    webClient.DownloadFile("localhost/Download/DownloadFile", @"c:\temp\local.txt");
    webClient.Dispose();
    webClient2 = new WebClient();
    webClient2.QueryString.Add("downloadId", id);
    webClient2.QueryString.Add("fileLength", GetFileLength(@"c:\temp\local.txt"));
    var i = webClient2.DownloadString("localhost/Download/VerifyFile");
    webClient2.Dispose();
Or wrap them in a using statement:
    using (WebClient webClient = new WebClient())
    {
        webClient.QueryString.Add("downloadId", id);
        webClient.DownloadFile("localhost/Download/DownloadFile", @"c:\temp\local.txt");
    }
    using (WebClient webClient = new WebClient())
    {
        webClient2 = new WebClient();
        webClient2.QueryString.Add("downloadId", id);
        webClient2.QueryString.Add("fileLength", GetFileLength(@"c:\temp\local.txt"));
        var i = webClient2.DownloadString("localhost/Download/VerifyFile");
    }
