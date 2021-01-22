    [ProtoContract]
    class EntryItem {
        [ProtoMember(1)]
        public int? Int32Value {get;set;}
        [ProtoMember(2)]
        public float? SingleValue {get;set;}
        [ProtoMember(3)]
        public string StringValue {get;set;}
    }
    [ProtoContract]
    class Entry {
        [ProtoMember(1)]
        public List<EntryItem> Items {get; set;}
    }
