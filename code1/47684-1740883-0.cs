            using (MemoryStream ms = new MemoryStream())
            {
                
                    NetDataContractSerializer serializer = new NetDataContractSerializer();
                    serializer.Serialize(ms, source);
                    return System.Text.Encoding.ASCII.GetString(ms.ToArray());
                
            }
        }
        public static T DeSerializeEntity<T>(string xml)
        {
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(xml)))
            {
                    NetDataContractSerializer serializer = new NetDataContractSerializer();
                    return (T)serializer.Deserialize(ms);
            }
        }
