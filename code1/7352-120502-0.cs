    public class MyXElement : XElement 
    {
    
        public MyXElement(XElement element)
            : base(element)
        { }
    
        public static bool TryParse(string xml, out MyXElement myElement)
        {
            XElement xmlAsXElement;
    
            try
            {
                xmlAsXElement = XElement.Parse(xml);
            }
            catch (XmlException)
            {
                myElement = null;
                return false;
            }
    
            // Use LINQ to check if xmlAsElement has correct nodes...
        }
