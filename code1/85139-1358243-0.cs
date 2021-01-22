        [XmlRoot(ElementName = "Example1")]
            public class Blah
            {
                public string Part1 { get; set; }
            }
    
                Blah bl = new Blah();
                bl.Part1 = "MyPart1";
                // Serialization
    
                /* Create an XmlSerializerNamespaces object and add two prefix-namespace pairs. */
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("namespace", "test");
                
                XmlSerializer s = new XmlSerializer(typeof(Blah),"test");
                TextWriter w = new StreamWriter(@"c:\list.xml");
                s.Serialize(w, bl,ns);
                w.Close();
    /* Output */
    <?xml version="1.0" encoding="utf-8"?>
    <namespace:Example1 xmlns:namespace="test">
      <namespace:Part1>MyPart1</namespace:Part1>
    </namespace:Example1>
