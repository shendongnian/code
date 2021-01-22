        public static XmlElement xmlValidationElement =
            new XmlDocument().CreateElement("validator");
        static void Main(string[] args)
        {
            string[] inputs = { "Hello", "World", "StackOverflow", "ServerFault" };
            foreach (string item in inputs)
            {
                try
                {
                    xmlValidationElement.InnerXml = item;
                }
                catch (XmlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
