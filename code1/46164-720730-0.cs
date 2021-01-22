        class Status
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
        static void Main()
        {
            string xml = @"<xml>
    <status id=""1""><text>abcdef</text></status>
    <status id=""2""><text>ghijkl</text></status>
    <status id=""3""><text>mnopqr</text></status></xml>";
            XDocument doc = XDocument.Parse(xml);
            var list = (from el in doc.Root.Elements("status")
                       select new Status
                       {
                           Id = (int)el.Attribute("id"),
                           Text = (string)el.Element("text")
                       }).ToList();
        }
