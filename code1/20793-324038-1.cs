    public class EntityMap : ClassMap<Entity> {
     public EntityMap() {
        Id(x => x.Id)
        JoinedSubClass<SubClass>("SubClassId", sub => { 
              sub.Map(x => x.Name); 
              sub.Map(x => x.SomeProperty); 
        });
     }
    }
