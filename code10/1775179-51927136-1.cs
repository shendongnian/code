    public class Blah {
        public Yadda1 Yadda1 { get; set; }
        public Yadda2 Yadda2 { get; set; }
        public Yadda3 Yadda3 { get; set; }
        
        [XmlElement("contentX", typeof(ContentX))]
        [XmlElement("contentY", typeof(ContentY))]
        [XmlChoiceIdentifier(nameof(PayloadType))]
        public Payload Payload { get; set; }
        
        public PayloadType PayloadType { get; set; }
    }
    public abstract class Payload { ... }
    public class ContentX : Payload { ... }
    public class ContentY : Payload { ... }
    [XmlType]
    public enum PayloadType
    {
        [XmlEnum("contentX")]
        ContentX,
        [XmlEnum("contentY")]
        ContentY,
    }
