     // Deserialize a JSON string to a given object.  
     public static T ReadToObject<T>(string json) where T: class, new()
     { 
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
        {
           return ser.ReadObject(stream) as T;
        }
     }
