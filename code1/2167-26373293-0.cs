    [XmlRoot]
    public class MyClass {
        public abstract class MyAbstract {} 
        public class MyInherited : MyAbstract {} 
        [XmlArray(), XmlArrayItem(typeof(MyInherited))] 
        public MyAbstract[] Items {get; set; } 
    }
