    Filelist data = new Filelist(); // replaces List<string>
    // fill
    
    using (var stream = File.Create(@".\data.xml"))
    {
        var formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        formatter.Serialize(stream, data);
    }    
    data = null; // loose it
    
    using (var stream = File.OpenRead(@".\data.xml"))
    {
        var formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
        data = (Filelist) formatter.Deserialize(stream);
    }
