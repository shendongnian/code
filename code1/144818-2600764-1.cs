    public static class XmlUtilities
    {
        public static bool IsXml(this string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            try
            {
                var doc = XElement.Parse(data)
                return true;            
            }
            catch
            {
                return false;
            }
        }
    }
