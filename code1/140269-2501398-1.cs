    class Foo { 
        public Foo (string name) { 
            Name1 = name; 
            Name2 = name; 
        } 
     
        [XmlAttribute] 
        public string Name1 { get; set; } 
     
        [XmlAttribute] 
        public string Name2; 
    } 
     
    Foo myFoo = new Foo("FirstName", "LastName");
    StreamWriter wr = new StreamWriter("path.xml"); 
    XmlSerializer serializer = new XmlSerializer(typeof(Foo));
    serializer.Serialize(wr,  myFoo);
