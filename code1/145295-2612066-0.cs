    [XmlRoot(Namespace="")]
    public class MyClass {
    
        [XmlArray("Children")]
        [XmlArrayItem("ConcreteTypeA", typeof(ConcreteTypeA))]
        [XmlArrayItem("ConcreteTypeB", typeof(ConcreteTypeB))]
        public BaseType[] Children {
            get;
            set;
        }
    
    }
    
    public class BaseType {
    }
    
    public class ConcreteTypeA : BaseType {
    }
    
    public class ConcreteTypeB : BaseType {
    }
