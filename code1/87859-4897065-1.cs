    static void Main(string[] args)
    {
        Foo foo = new Foo();
        foo.Field1 = "Pluto";
        foo.Field2 = "Pippo";
        foo.Field3 = "Topolino";
        foo.Field4 = "Paperino";
        XmlSerializer ser = new XmlSerializer(typeof(Foo));
        ser.Serialize(Console.Out, foo);
        Console.ReadLine();
    }
    [XmlRoot("Sample")]
    public class Foo
    {   
        public Foo() { }
        [XmlElement("Alfa_64")]
        public Base64String Field1;
        
        [XmlElement("Beta")]
        public string Field2;
        [XmlElement("Gamma_64")]
        public Base64String Field3;
        [XmlElement("Delta_64")]
        public Base64String Field4;
    }
