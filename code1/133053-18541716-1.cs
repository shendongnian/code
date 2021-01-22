    public class MyMappingOverride : IAutoMappingOverride<MyClass> {
           public void Override(AutoMapping<MyClass> mapping) {
               mapping.Map(x => x.LongName).Length(765);
           }
    }
	
