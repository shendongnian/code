    Filelist data = new Filelist();
    // fill
    
    using (var strm = File.Create(@".\data.xml"))
    {
        var ser = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        ser.Serialize(strm, data);
    }    
    data = null; // loose it
    
    using (var strm = File.OpenRead(@".\data.xml"))
    {
        var ser = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        data = (Filelist) ser.Deserialize(strm);
    }
