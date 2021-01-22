    public class EntityMap : ClassMap<Entity> {
     public EntityMap() {
        Id(x => x.Id)
        AddPart(new SubClassMap()); // Adds the subclass mapping!
     }
    }
    public class SubClassMap : JoinedSubClassPart<SubClass>
    {
        public SubClassMap()
            : base("SubClassId")
        {
             Map(x => x.Name); 
             Map(x => x.SomeProperty); 
        }
    }
