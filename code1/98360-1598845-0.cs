    [XmlRoot("Root")]
    public class Test
    {
    TypeClass type=null;
    [XmlElement("Type")]
    public TypeClass Type
    {
    get{return type;}
    set{type=value;}
    }
    }
    [XmlRoot("Type")]
    public class TypeClass
    {
    int _value=0;
    [XMlAttribute]
    public int Value
    {
    get{return _value;}
    set{_value=value;}
    }
    }
