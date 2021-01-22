         public static Dictionary<string, string> XmlToDictionary
                                            (string key, string value, XElement baseElm)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (XElement elm in baseElm.Elements())
                { 
                    string dictKey = elm.Attribute(key).Value;
                    string dictVal = elm.Attribute(value).Value;
                    dict.Add(dictKey, dictVal);
                    
                }
                return dict;
            }
