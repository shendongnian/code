    string feedUrl = "https://sports.ultraplay.net/sportsxml?clientKey=b4dde172-4e11-43e4-b290-abdeb0ffd711&sportId=1165";
    
    System.Xml.Linq.XDocument content;
    using (System.Net.WebClient webClient = new System.Net.WebClient())
    using (System.IO.Stream stream = webClient.OpenRead(feedUrl))
    using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.UTF8))
    {
    	content = XDocument.Load(streamReader);
    }
    Console.WriteLine(content);
