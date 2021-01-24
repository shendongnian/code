    public abstract class Element
    {
        public Element(
            XmlElement xml)
        {
        }
    }
    
    public sealed class ClassA
        : Element
    {
        public ClassA(XmlElement xml) : base(xml)
        {
        }
    }
    
    public sealed class ClassB
        : Element
    {
        public ClassB(XmlElement xml) : base(xml)
        {
        }
    }
    
    public sealed class ClassC
        : Element
    {
        public ClassC(XmlElement xml) : base(xml)
        {
        }
    }
