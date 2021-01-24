    [XmlInclude(typeof(A))]
    [XmlInclude(typeof(B))]
    ...
    public class BaseClass {}
    
    [XmlRoot("a")]
    public class A : BaseClass { }
    [XmlRoot("b")]
    public class B : BaseClass { }
    ...
    public class Things
    {
       [XmlElement("things")]
       public BaseClass[] Items { get; set; }
    }
