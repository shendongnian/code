    public static class XmlUtilities
    {
        [DebuggerStepThrough]
        public static bool IsXml(this string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            try
            {
                var doc = XElement.Parse(data)
                return true;            
            }
            catch (XmlException)
            {
                return false;
            }
        }
    }
