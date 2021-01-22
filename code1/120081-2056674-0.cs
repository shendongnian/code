    public static string Serialize<T>(T t, IEnumerable<System.Type> types, bool preserveReferences)
        {
            StringBuilder aStringBuilder = new StringBuilder();
            using (StringWriter aStreamWriter = new StringWriter(aStringBuilder))
            {
                DataContractSerializer aDCS;
                using (XmlTextWriter aXmlTextWriter = new XmlTextWriter(aStreamWriter))
                {
                    aDCS = new DataContractSerializer( typeof( T ), types, int.MaxValue, false, preserveReferences, null );
                    aDCS.WriteObject(aXmlTextWriter, t);
                }
            }
            return aStringBuilder.ToString();
        }
