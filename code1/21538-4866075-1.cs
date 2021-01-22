        private static void GenerateXMlFromLinqQry()
        {
            BookParticipant[] bookParticipants = new[] {new BookParticipant {FirstName = "Joe", LastName = "Rattz",
                                                        ParticipantType = ParticipantTypes.Author},
                                                        new BookParticipant {FirstName = "Ewan", LastName = "Buckingham",
                                                        ParticipantType = ParticipantTypes.Editor}
                                                        };
            XElement xBookParticipants =
            new XElement("BookParticipants",
                         bookParticipants.Select(p =>
                    new XElement("BookParticipant",
                    new XAttribute("type", p.ParticipantType),
                    new XElement("FirstName", p.FirstName),
                    new XElement("LastName", p.LastName))));
            Console.WriteLine(xBookParticipants);
        }
        //-- Obtaining Elements Without Reaching
        private static void WithoutReaching()
        {
            XDocument xDocument = new XDocument(new XElement("BookParticipants",
                                                new XElement("BookParticipant",
                                                new XAttribute("type", "Author"),
                                                new XElement("FirstName", "Joe"),
                                                new XElement("LastName", "Rattz")),
                                                new XElement("BookParticipant",
                                                new XAttribute("type", "Editor"),
                                                new XElement("FirstName", "Ewan"),
                                                new XElement("LastName", "Buckingham"))));
            IEnumerable<XElement> elements = xDocument.Descendants("BookParticipant");
            foreach (XElement element in elements)
            {
                Console.WriteLine("Element: {0} : value = {1}",
                element.Name, element.Value);
            }
            IEnumerable<XElement> elements1 = xDocument.Descendants("BookParticipant")
                                                       .Where(e => ((string)e.Element("FirstName")) == "Ewan");
            foreach (XElement element1 in elements1)
            {
                Console.WriteLine("Element: {0} : value = {1}",
                element1.Name, element1.Value);
            }
        }
