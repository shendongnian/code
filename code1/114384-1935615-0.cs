    public static List<T> FromXML<T>(this string s) where T : class
            {
                var ls = new List<T>();
                var xml = new XmlSerializer(typeof(List<T>));
                var sr = new StringReader(s);
                var xmltxt = new XmlTextReader(sr);
                if (xml.CanDeserialize(xmltxt))
                {
                    ls = (List<T>)xml.Deserialize(xmltxt);
                }
                return ls;
            }
