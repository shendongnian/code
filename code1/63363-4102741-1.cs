    public class ParentMap : ClassMap<Parent>
    {
      public ParentMap()
      {
        Id(x => x.Id);
        Map(x => x.Name);
     
        DiscriminateSubClassesOnColumn("type");
      }
    }
     
    public class ChildMap : SubclassMap<Child>
    {
      public ChildMap()
      {
        Map(x => x.AnotherProperty);
      }
    } 
