    public class XmlTest
    {
        private XDocument _doc;
        public XmlTest(string xml)
		{
			_doc = XDocument.Load(new StringReader(xml);
		}
        public string Icon { get { return GetValue("Icon"); } }
        private string GetValue(string elementName)
        {
            return _doc.Descendants(elementName).FirstOrDefault().Value;
        }
    }
