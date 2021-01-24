    [DataAccessObject]
    public abstract class A : DataAccessObject<uint>
    {
        [PersistedMember(Name = "Id")]
		public abstract override uint Id { get; set; }
        [PersistedMember]
        public abstract string Data { get; set; }
    }
    
    [DataAccessObject]
    public abstract class B : DataAccessObject<A>
    {
        [PersistedMember(Name = "Id", PrefixName = "")]
		public abstract override A Id { get; set; }
        [PersistedMember]
        public abstract string MoreData { get; set; }
    }
