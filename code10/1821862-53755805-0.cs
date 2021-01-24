    using System.Net;
    
    string content = "";
    using (WebClient client = new WebClient ()) // WebClient class inherits IDisposable
    {
        content = client.DownloadString("http://yoursite.com/content.txt");
    }
