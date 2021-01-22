        [ProtoMember(1)]
        public List<SomeOtherType> Items {get {return items;}}
        private readonly List<SomeOtherType> items = new List<SomeOtherType>();
        [DefaultValue(false), ProtoMeber(2)]
        private bool IsEmptyList {
            get { return items.Count == 0; }
            set { }
        }
