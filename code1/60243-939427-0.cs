    // Serializing NameValueCollection object by using SoapFormatter
    SoapFormatter sf = new SoapFormatter();
    Stream strm1 = File.Open(@"C:\datasoap.xml", FileMode.OpenOrCreate,FileAccess.ReadWrite);
    sf.Serialize(strm1,namValColl);
    strm1.Close();
			
    // Deserializing the XML file into NameValueCollection object
    // by using SoapFormatter
    SoapFormatter sf1 = new SoapFormatter();
    Stream strm2 = File.Open(@"C:\datasoap.xml", FileMode.Open,FileAccess.Read);
    NameValueCollection namValColl1 = (NameValueCollection)sf1.Deserialize(strm2);
    strm2.Close();
