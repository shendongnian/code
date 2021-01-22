    XDocument xdoc = XDocument.Load("C:\\test.xml");
    List<Coordinate> list = new List<Coordinate>();
    foreach (var coordinate in xdoc.Descendants("coordinate"))
    {
        string time = coordinate.Attribute("time").Value;
        string initial = coordinate.Element("initial").Value;
        string final = coordinate.Element("final").Value;
        list.Add(new Coordinate { Time = time, Initial = initial, Final = final });
    }
