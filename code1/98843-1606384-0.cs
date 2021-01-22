        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        static int Main(string[] args)
        {
            string xml = "<Data>  <MaxCount>10</MaxCount>  <Points>    <Point X=\"10\" Y=\"10\"/>    <Point X=\"20\" Y=\"10\"/>    <Point X=\"30\" Y=\"10\"/>    <Point X=\"40\" Y=\"10\"/>    <Point X=\"50\" Y=\"10\"/>    <Point X=\"60\" Y=\"10\"/>  </Points></Data>";
            XDocument doc = XDocument.Parse(xml);
            int maxCount = int.Parse(doc.Element("Data").Element("MaxCount").Value);
            var points = from e in doc.Element("Data").Element("Points").Elements("Point")
                         select new Point
                         {
                             X = int.Parse(e.Attribute("X").Value),
                             Y = int.Parse(e.Attribute("Y").Value)
                         };
            Console.WriteLine("MaxCount: {0}", maxCount);
            foreach (var item in points)
            {
                Console.WriteLine("Point: {0},{1}", item.X, item.Y);
            }
        }
