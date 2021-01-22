    XElement rssFile = XElement.Load(content);
    IEnumerable<XElement> channels = rssFile.Descendants("channel");
    foreach(XElement channel in channels)
    {
        Console.WriteLine("link: " + channel.Element("link").Value);
        Console.WriteLine("description: " + channel.Element("description").Value);
    }
