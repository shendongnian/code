    System.Net.WebClient webClient = new System.Net.WebClient();
    webClient.Encoding = Encoding.UTF8;
    string xmlString = webClient.DownloadString("https://sports.ultraplay.net/sportsxml?clientKey=b4dde172-4e11-43e4-b290-abdeb0ffd711&sportId=1165");
    System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Parse(xmlString);
    Console.WriteLine(xdoc);
