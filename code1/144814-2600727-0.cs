    public static class XmlUtilities
    {
        public static bool IsXml(this string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
    
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    
                doc.LoadXml(data);
    
                return true;            
            }
            catch
            {
                return false;
            }
        }
    }
