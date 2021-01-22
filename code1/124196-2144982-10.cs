    XDocument xdoc = XDocument.Load("C:\\test.xml");
    IEnumerable<XElement> cords= xdoc.Descendants("coordinate");
    var coordinates = cords
                      .Select(x => new Coordinate()
                                       {
                                          Time = x.Attribute("time").Value,
                                          Initial = x.Attribute("initial").Value,
                                          Final = x.Attribute("final").Value
                                        });
