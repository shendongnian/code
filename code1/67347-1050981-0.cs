    [DataContract(Name="foo")]
    public class Foo
    {
        [DataMember(Name="bar")]
        public string Bar { get; set; }
        public int ThisIsntSerialized {get;set;}
    }
