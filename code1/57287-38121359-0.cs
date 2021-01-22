        [DebuggerNonUserCode]
        public static bool XElementTryParse(string data, out XElement result)
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
