        public static string SerializeDict()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict["key"] = "value1";
            dict["key2"] = "value2";
            // serialize the dictionary
            DataContractSerializer serializer = new DataContractSerializer(dict.GetType());
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sw))
                {
                    // add formatting so the XML is easy to read in the log
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, dict);
                    writer.Flush();
                    return sw.ToString();
                }
            }
        }
