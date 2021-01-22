        XmlSerializer s1= new XmlSerializer(typeof(MyClass)); 
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add( "", "" );
        MyClass c= new MyClass();
        c.PropertyFromDerivedClass= "Hallo";
        sw = new System.IO.StringWriter();
        s1.Serialize(new XTWND(sw), c, ns);
        ....
       /// XmlTextWriterFormattedNoDeclaration
       /// helper class : eliminates the XML Documentation at the
       /// start of a XML doc. 
       /// XTWFND = XmlTextWriterFormattedNoDeclaration
       public class XTWFND : System.Xml.XmlTextWriter
       {
         public XTWFND(System.IO.TextWriter w) : base(w) { Formatting = System.Xml.Formatting.Indented; }
         public override void WriteStartDocument() { }
       }
