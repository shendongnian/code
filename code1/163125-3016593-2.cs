    using (ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
    {
         ser = new DataContractJsonSerializer(typeof(MyObject)); 
         MyObject obj = ser.ReadObject(ms) as MyObject;
         
         int myObjID = obj.ID;
         string myObjName = obj.Name;
    }
    
