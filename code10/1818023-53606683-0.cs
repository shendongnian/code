    public class HelperSerializer<T> where T: class
    { 
        public static string WriteFromObject(T source)
        {
            using (var ms = new MemoryStream())            {  
                var ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(ms, source);
                byte[] json = ms.ToArray();
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }
        }
        // Deserialize a JSON stream to an object.  
        public static T ReadToObject(string json)
        {          
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                return ser.ReadObject(ms) as T;
            }
        }
        
    }
