    [Serializable, XmlRoot("args")]
    public class SomeArgs {
        [XmlElement("foo")] public string Foo { get; set; } 
        [XmlAttribute("bar")] public int Bar { get; set; }
    }
    ...
    SomeArgs args = new SomeArgs { Foo = "abc", Bar = 123 };
    XmlSerializer ser = new XmlSerializer(typeof(SomeArgs));
    StringWriter sw = new StringWriter();
    ser.Serialize(sw, args);
    string xml = sw.ToString();
