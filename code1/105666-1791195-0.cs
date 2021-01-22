    [ActiveRecord]
    public class Parent
    {
        [PrimaryKey(PrimaryKeyType.GuidComb)]
        public Guid Id { get; set; }
    
        [HasMany(Cascade = ManyRelationCascadeEnum.SaveUpdate, Inverse=true)]
        public IList<Child> Children { get; set; }
    }
