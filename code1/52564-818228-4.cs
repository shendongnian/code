     using System.IO;
     using System.Runtime.Serialization.Json;
        
        public static class JsonExtensions
        {
            public static string ToJson<T>(this T instance) 
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    serializer.WriteObject(memoryStream, instance);
    
                    memoryStream.Flush();
                    memoryStream.Position = 0;
    
                    using (var reader = new StreamReader(memoryStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
    
            public static T FromJson<T>(this string serialized) 
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (StreamWriter writer = new StreamWriter(memoryStream))
                    {
                        writer.Write(serialized);
                        writer.Flush();
    
                        memoryStream.Position = 0;
    
                        return (T)serializer.ReadObject(memoryStream);
                    }
                }
            }
        }
