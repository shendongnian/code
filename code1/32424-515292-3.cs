            XDocument doc = XDocument.Parse(xml);
            var nodes =
                from file in doc.Document
                    .Element("GateKeeperFiles")
                    .Elements("File")
                select new {
                       Node = file,
                       Version = new Version(
                         (int) file.Element("Major"),
                         (int) file.Element("Minor"),
                         (int) file.Element("Build"),
                         (int) file.Element("Revision"))
                       } into tmp
                    orderby tmp.Version descending
                    select tmp;
            var mostRecentVersion = nodes.Select(x => x.Version).FirstOrDefault();
            var files = nodes.TakeWhile(x => x.Version == mostRecentVersion);
            foreach(var file in files) {
                Console.WriteLine("{0}: {1}",
                    file.Version,
                    (string)file.Node.Element("Name"));
            }
