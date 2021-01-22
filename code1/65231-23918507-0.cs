    public class SerializableBase
    {
        public bool Property1 { get; set;}
        public bool Property2 { get; set;}
        public bool Property3 { get; set;}
        public virtual bool ShouldSerializeProperty2 { get { return false; } }
    }
    [XmlRoot("Object")]
    public class SerializableObject1 : SerializableBase
    {        
    }
    [XmlRoot("Object")]
    public class SerializableObject2 : SerializableBase
    {
        public override bool ShouldSerializeProperty2 { get { return true; } }
    }
