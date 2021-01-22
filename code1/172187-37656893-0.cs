    using System.IO;
    using System.Net;
    
    WebClient client = new WebClient();
    
    string dnlad = client.DownloadString("http://www.stackoverflow.com/");
    
    File.WriteAllText(@"c:\Users\Admin\Desktop\Data1.txt", dnlad);
