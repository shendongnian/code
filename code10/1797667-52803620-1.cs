    public interface Interface1 { }
    public interface Interface2 { }
    public interface Interface3 { }
    public interface DerivedInterface1 : Interface1 { }
    public interface DerivedInterface2 : Interface2 { }
    public class Test : DerivedInterface1, DerivedInterface2, Interface3 { }
    
    var result = typeof(Test).DumpInterface();
    //Contains only DerivedInterface1, DerivedInterface2, Interface3 
    
