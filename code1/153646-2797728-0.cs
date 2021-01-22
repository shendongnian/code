    XElement document = XElement.Load("path to the file");
    List<string> sources = new List<string>();
    foreach (var mediaElement in document.Descendents("media"))
    {
       if (sources.Contains((string)mediaElement.Attributes("src"))
       {
          mediaElement.Remove();
       }
       else
       {
          sources.Add((string)mediaElement.Attributes("src"));
       }
    }
    document.Save("path to the file");
