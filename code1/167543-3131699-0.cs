       public class ChildMap : IAutoMappingOverride<Child>
       {
           public void Override(AutoMapping<Child> mapping)
           {
               mapping.References(x => x.OtherThing)
                   .Nullable();
           }
       }
