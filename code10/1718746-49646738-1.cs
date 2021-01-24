    [ProtoContract] // you can keep the [Serializable] for compat if you want
    public class Custom {
        [ProtoMember(1)]
        public int Id {get;set;}
        [ProtoMember(2)]
        public string Name {get;set;}
        // ...etc
    }
