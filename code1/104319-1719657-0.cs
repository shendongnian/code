    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MyObject));
    Stream s = new MemoryStream();
    MyObject obj = new MyObject { .. set properties .. };
    ser.WriteObject(s, obj);
    s.Seek( SeekOrigin.Begin );
    var reader = new StreamReader(s);
    string json_string = reader.ReadToEnd();
