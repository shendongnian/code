    static void Main(string[] args)
    {
        int x = 0;
        var MyInfoCollection = new[]{
            new {Value = "hello world", Key = x++ },
            new {Value = (string)null, Key = x++},
            new {Value = "Test2", Key = x++}
        };
        var MyXDocument = new XElement("ROOT",
                                        new XElement("ERRORS")
                                      );
        //===
        var errorTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff");
        var errorQuery = from item in MyInfoCollection
                         where string.IsNullOrEmpty(item.Value)
                         let sequenceNumber = item.Key + 1
                         let detail = "No information was read for expected " +
                                      "sequence number " + sequenceNumber
                         select new XElement("ERROR",
                            new XElement("DATETIME", errorTime),
                            new XElement("DETAIL", detail),
                            new XAttribute("TYPE", "MISSED"),
                            new XElement("PAGEID", sequenceNumber)
                            );
        var errors = MyXDocument.Descendants("ERRORS").FirstOrDefault();
        if (errors != null)
            errors.Add(errorQuery);
    }
