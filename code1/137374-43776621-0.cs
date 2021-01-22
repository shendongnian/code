    public static string SerializeObject<T>(T objectToSerialize)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                MemoryStream memStr = new MemoryStream();
    
                try
                {
                    bf.Serialize(memStr, objectToSerialize);
                    memStr.Position = 0;
    
                    return Convert.ToBase64String(memStr.ToArray());
                }
                finally
                {
                    memStr.Close();
                }
            }
    
            public static T DerializeObject<T>(string objectToDerialize)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                byte[] byteArray = Convert.FromBase64String(objectToDerialize);
                MemoryStream memStr = new MemoryStream(byteArray);
    
                try
                {
                    return (T)bf.Deserialize(memStr);
                }
                finally
                {
                    memStr.Close();
                }
            }
