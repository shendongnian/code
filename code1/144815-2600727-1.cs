    public static class XmlUtilities
    {
        [DebuggerStepThrough]
        public static bool IsXml(this string data)
        {
            if (String.IsNullOrEmpty(data)) return false;
    
            try
            {
                var doc = new XmlDocument();
    
                doc.LoadXml(data);
    
                return true;            
            }
            catch (XmlException)
            {
                return false;
            }
        }
    }
