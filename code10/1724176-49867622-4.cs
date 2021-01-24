    XDocument xdoc = XDocument.Parse(xmlString);
    var music = xdoc.Descendants().Where(x => x.Name == "music");
    var parents = music.Ancestors().Reverse()
        .Select(a=>new XElement(a.Name.LocalName)).ToArray();
    XElement root = new XElement(xdoc.Root.Name.LocalName);
    XDocument xdoc2 = new XDocument(root);
    XElement lastAdded = root;
    for (int i = 1; i < parents.Count(); i++)
    {
        lastAdded.Add(parents[i]);
        lastAdded = parents[i];
    }
    lastAdded.Add(music);
    Console.WriteLine(xdoc2.ToString());
