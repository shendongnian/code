    [ProtoContract]
    class SomeType {
        [ProtoMember(1)]
        public List<SomeOtherType> Items {get;set;}
        [DefaultValue(false), ProtoMeber(2)]
        private bool IsEmptyList {
            get { return Items != null && Items.Count == 0; }
            set { if(value) {Items = new List<SomeOtherType>();}}
        }
    }
