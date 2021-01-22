      public class TestSer
        {
            public int? MyProperty { get; set; }   
        }
      
  
        TestSer ser = new TestSer();
        ser.MyProperty = null;
        StringBuilder bldr = new StringBuilder();
        var ns = new System.Xml.Serialization.XmlSerializerNamespaces();
        ns.Add("", "");
        XmlSerializer s = new XmlSerializer(typeof(TestSer));
        using (StringWriter writer = new StringWriter(bldr))
        {
            s.Serialize(writer, ser, ns);
        }
