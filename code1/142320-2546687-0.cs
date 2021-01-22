    errorQuery = MyDocument.Descendants("RECORD")
                            .Where(x => itemsThatWasDuplicated.Contains((int)x.Element("DOCUMENTID")))
                            .GroupBy(a => a.Element("DOCUMENTID"), (innerID, values) => values.OrderBy(b => b.Element("ID").Value))
                            .Skip(1)
                            .SelectMany(p => p)
                            .Select(item => new XElement("ERROR",
                                              new XElement("DATETIME", time),
                                              new XElement("DETAIL",  "Sequence number " + item.Element("DOCUMENTID").Value + " was read more than once"),
                                              new XAttribute("TYPE", "DUP"),
                                              new XElement("ID", item.Element("ID").Value)
                                              ));
