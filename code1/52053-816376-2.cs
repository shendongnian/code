    public class MyScanner : ITypeScanner {
      public void Process(Type type, PluginGraph graph) {
    
        if(type.BaseType == null) return;
    
        if(type.BaseType.Equals(typeof(PersonBase))) {
          graph.Configure(x => 
            x.ForRequestedType<PersonBase>()
            .TheDefault.Is.OfConcreteType(type));
        }
      }
    } 
