    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument doc = new XmlDocument();
            //XmlElement newBook=doc.CreateElement("BookParticipant");
            //newBook.SetAttribute("Author");
            //Using Functional Construction to Create an XML Schema
            XElement xBookParticipant = new XElement("BookParticipant",
                                            new XElement("FirstName", "Joe"),
                                            new XElement("LastName", "Rattz"));
            Console.WriteLine(xBookParticipant.ToString());
            //Creates the Same XML Tree as Listing 6-1 but with Far Less Code
            XElement xBookParticipants = new XElement("BookParticipants",
                                            new XElement("BookParticipant",
                                            new XAttribute("type", "Author"),
                                            new XElement("FirstName", "Joe"),
                                            new XElement("LastName", "Rattz")),
                                            new XElement("BookParticipant",
                                            new XAttribute("type", "Editor"),
                                            new XElement("FirstName", "Ewan"),
                                            new XElement("LastName", "Buckingham")));
            Console.WriteLine(xBookParticipants.ToString());
            //-- Disadvatages of XML document
            //System.Xml.XmlElement xmlBookParticipant = new System.Xml.XmlElement("BookParticipant");
            XElement xeBookParticipant = new XElement("BookParticipant");
            XDocument xDocument = new XDocument(new XElement("BookParticipants",
                                                new XElement("BookParticipant",
                                                new XAttribute("type", "Author"),
                                                new XElement("FirstName", "Joe"),
                                                new XElement("LastName", "Rattz"))));
            Console.WriteLine(xDocument.ToString());
            //--Calling the ToString Method on an Element Produces the XML Tree
            XElement name = new XElement("Name", "Joe");
            Console.WriteLine(name.ToString());
            //--Console.WriteLine Implicitly Calling the ToString Method on an Element to Produce an XML Tree
            XElement name1 = new XElement("Person",
                                          new XElement("FirstName", "Joe"),
                                          new XElement("LastName", "Rattz"));
            Console.WriteLine(name1);
            //-- Casting an Element to Its Value’s Data Type Outputs the Value
            Console.WriteLine(name);
            Console.WriteLine((string)name);
            //--Different Node Value Types Retrieved via Casting to the Node Value’s Type
            XElement count = new XElement("Count", 12);
            Console.WriteLine(count);
            Console.WriteLine((int)count);
            XElement smoker = new XElement("Smoker", false);
            Console.WriteLine(smoker);
            Console.WriteLine((bool)smoker);
            XElement pi = new XElement("Pi", 3.1415926535);
            Console.WriteLine(pi);
            Console.WriteLine((double)pi);
            DeferredQryProblem();
            GenerateXMlFromLinqQry();
            WithoutReaching();
            Ancestors();
            AncestorsAndSelf();
            SortSample();
            FindElementwithSpecificChild();
        }
        private static void DeferredQryProblem()
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
            xDocument.Element("BookParticipants").Elements("BookParticipant");
            foreach (XElement element in elements)
            {
                Console.WriteLine("Source element: {0} : value = {1}",
                element.Name, element.Value);
            }
            foreach (XElement element in elements)
            {
                Console.WriteLine("Removing {0} = {1} ...", element.Name, element.Value);
                element.Remove();
            }
            Console.WriteLine(xDocument);
            foreach (XElement element in elements)
            {
                Console.WriteLine("Source element: {0} : value = {1}",
                element.Name, element.Value);
            }
            foreach (XElement element in elements.ToArray())
            {
                Console.WriteLine("Removing {0} = {1} ...", element.Name, element.Value);
                element.Remove();
            }
            Console.WriteLine(xDocument);
        }
        //-- Creating an Attribute and Adding It to Its Element
        private static void CreatingAttribute()
        {
            XElement xBookParticipant = new XElement("BookParticipant", new XAttribute("type", "Author"));
            Console.WriteLine(xBookParticipant);
        }
        //--Creating a Comment with Functional Construction
        private static void CreatingComment()
        {
            XElement xBookParticipant = new XElement("BookParticipant",
                                                      new XComment("This person is retired."));
            Console.WriteLine(xBookParticipant);
        }
        //--Creating a Declaration with Functional Construction
        private static void CreateXmlDeclaration()
        {
            XDocument xDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
