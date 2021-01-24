    public static class ReWriteProcessor
        {
            public static Dictionary<string, string> MapedUrls { get;}
    
            static ReWriteProcessor()
            {
                MapedUrls = GetKeyValuePairs();
            }
           
    
            private static Dictionary<string,string> GetKeyValuePairs()
            {
                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                XDocument doc = XDocument.Load(WolfAppData.ReWriteMapFile);
                if (doc.Descendants().Any())
                {
                    var elements = doc.Descendants("rewriteMap").Elements().ToList();
                   foreach (XElement element in elements)
                    {
                       string key =   element.FirstAttribute.Value;
                        string value = element.LastAttribute.Value;
                        if(!keyValues.ContainsKey(key))
                            keyValues.Add(key,value);
                    }
                }
    
                return keyValues;
            }
    
        }
