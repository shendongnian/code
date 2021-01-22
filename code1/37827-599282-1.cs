    using System.Net;
    //...
    using (WebClient client = new WebClient ()) // WebClient class inherits IDisposable
    {
        client.DownloadFile("http://yoursite.com/page.html", @"C:\localfile.html");
        // Or you can get the file content without saving it:
        string htmlCode = client.DownloadString("http://yoursite.com/page.html");
        //...
    }
