    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    
    [XmlRoot("root")]
    public class MyClass
    {
        public MyClass()
        {
    
        }
    
        public string product { get; set; }
    
        [XmlElement("SomeHighLevelElement")]
        public List<SomeHighLevelElement> ListWrapper { get; set; }
    
    }
    
    public class SomeHighLevelElement
    {
        public AnotherElment anotherElment { get; set; }
    }
    
    public class AnotherElment
    {
        public string lowestElement { get; set; }
    }
