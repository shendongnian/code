    [DataContract]
    public class Parent
    {
        [DataMember(Name = "parentItem")]
        public virtual string Item { get; set; }
    }
    
    [DataContract]
    public class Child : Parent 
    {
        [DataMember(Name = "childItem")]
        public override string Item { get; set; }
    }
