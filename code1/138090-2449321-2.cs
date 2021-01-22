    static void Main(string[] args)
    {
        var MyInfoCollection = (from key in Enumerable.Range(0, 100000)
                                let value = (MoreRandom() % 10 != 0)
                                                        ? (string)null
                                                        : "H"
                                select new { Value = value, Key = key }
                               ).ToDictionary(k => k.Key, v => v.Value);
        var MyXDocument = new XElement("ROOT",
                                        new XElement("ERRORS")
                                      );
        var sw = Stopwatch.StartNew();
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
        //===
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds); //623
    }
    static RandomNumberGenerator rand = RandomNumberGenerator.Create();
    static int MoreRandom()
    {
        var buff = new byte[1];
        rand.GetBytes(buff);
        return buff[0];
    }
