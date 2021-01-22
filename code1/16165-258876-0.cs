    public static string ToJson(IEnumerable collection)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(collection.GetType());
                string json;
                using (MemoryStream m = new MemoryStream())
                {
                    XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(m);
                    ser.WriteObject(m, collection);
                    writer.Flush();
    
                    json = Encoding.Default.GetString(m.ToArray());
                }
                return json;
            }
