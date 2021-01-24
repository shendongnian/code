    DateTime now = DateTime.Now;
            
    string json = "";
    using (MemoryStream ms = new MemoryStream()) {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DateTime));
        ser.WriteObject(ms, now);
        byte[] jsonByte = ms.ToArray();
        json = Encoding.UTF8.GetString(jsonByte, 0, jsonByte.Length);
    }
    DateTime? deserializedDateTime = new DateTime();
    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedDateTime.GetType());
        deserializedDateTime = ser.ReadObject(ms) as DateTime?;
    }
    Console.WriteLine("Object to JSON:");
    Console.WriteLine(json);
    Console.WriteLine("JSON to Object:");
    Console.WriteLine(deserializedDateTime.ToString());
