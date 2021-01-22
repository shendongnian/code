    public class SerializableBase
    {
        [XmlElement(Order = 1)]
        public virtual bool Property1 { get; set;}
    
        [XmlElement(Order = 3)]
        public virtual bool Property3 { get; set;}
    }
    
    [XmlRoot("Object")]
    public class SerializableObject1 : SerializableBase
    {
    }
    
    [XmlRoot("Object")]
    public class SerializableObject2 : SerializableBase
    {
        [XmlElement(Order = 1)]
        public override bool Property1 
        { 
          get { return base.Property1; }
          set { base.Property1 = value; }
        }
    
        [XmlElement(Order = 2)]
        public bool Property2 { get; set;}
        
        [XmlElement(Order = 3)]
        public override bool Property3
        { 
          get { return base.Property3; }
          set { base.Property3 = value; }
        }
    }
