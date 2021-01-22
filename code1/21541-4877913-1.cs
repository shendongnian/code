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
            //-- Simple Descendants
            IEnumerable<XElement> elements = xDocument.Descendants("BookParticipant");
            
            foreach (XElement element in elements)
            {
                Console.WriteLine("Element: {0} : value = {1}",
                element.Name, element.Value);
            }
            //-- Descendants with Where Clause
            IEnumerable<XElement> elements1 = xDocument.Descendants("BookParticipant")
                                                       .Where(e => ((string)e.Element("FirstName")) == "Ewan");
            foreach (XElement element1 in elements1)
            {
                Console.WriteLine("Element: {0} : value = {1}",
                element1.Name, element1.Value);
            }
        }
        //-- Ancestors Prototype
        private static void Ancestors()
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
            IEnumerable<XElement> elements = xDocument.Element("BookParticipants").Descendants("FirstName");
            // First, I will display the source elements.
            foreach (XElement element in elements)
            {
                Console.WriteLine("Source element: {0} : value = {1}",
                element.Name, element.Value);
            }
            // Now, I will display the ancestor elements for each source element.
            foreach (XElement element in elements.Ancestors())
            {
                Console.WriteLine("Ancestor element: {0}", element.Name);
            }
            // Now, I will display the ancestor elements for each source element.
            foreach (XElement element in elements.Ancestors("BookParticipant"))
            {
                Console.WriteLine("Ancestor element: {0}", element.Name);
            }
        }
        //-- AncestorsAndSelf
        private static void AncestorsAndSelf()
        {
            XDocument xDocument = new XDocument(
                new XElement("BookParticipants",
                new XElement("BookParticipant",
                new XAttribute("type", "Author"),
                new XElement("FirstName", "Joe"),
                new XElement("LastName", "Rattz")),
                new XElement("BookParticipant",
                new XAttribute("type", "Editor"),
                new XElement("FirstName", "Ewan"),
                new XElement("LastName", "Buckingham"))));
            IEnumerable<XElement> elements =
            xDocument.Element("BookParticipants").Descendants("FirstName");
            // First, I will display the source elements.
            foreach (XElement element in elements)
            {
                Console.WriteLine("Source element: {0} : value = {1}",
                element.Name, element.Value);
            }
            // Now, I will display the ancestor elements for each source element.
            foreach (XElement element in elements.AncestorsAndSelf())
            {
                Console.WriteLine("Ancestor element: {0}", element.Name);
            }
            // Now, I will display the ancestor elements for each source element.
            foreach (XElement element in elements.AncestorsAndSelf("BookParticipant"))
            {
                Console.WriteLine("Ancestor element: {0}", element.Name);
            }
        }
        //-- Sort Smaple
        private static void SortSample()
        {
            XElement root = XElement.Load("Data.xml");
            IEnumerable<decimal> prices =
                from el in root.Elements("Data")
                let price = (decimal)el.Element("Price")
                orderby price
                select price;
            foreach (decimal el in prices)
                Console.WriteLine(el);
        }
        //-- Find an Element with a Specific Child 
        private static void FindElementwithSpecificChild()
        {
            XElement root = XElement.Load("data.xml");
            IEnumerable<XElement> tests =
                from el in root.Elements("Data")
                where (int)el.Element("Quantity") > 3
                select el;
            foreach (XElement el in tests)
                Console.WriteLine((string)el.Attribute("TestId");
        }
    }
