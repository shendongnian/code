    public IRelation
    {
       public string RelationshipType { get; set; }
    }
     
    public IGenericRelation<TParent, TChild> : IRelation
    {
        public TParent Parent { get; set; }
        public TChild Child { get; set; }
    }
