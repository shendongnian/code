    [System.Diagnostics.DebuggerNonUserCode]
    static class MyXElement
    {
        public static bool TryParse(string data, out XElement result)
        {
            try
            {
                result = XElement.Parse(data);
                return true;
            }
            catch (System.Xml.XmlException)
            {
                result = default(XElement);
                return false;
            }
        }
    }
