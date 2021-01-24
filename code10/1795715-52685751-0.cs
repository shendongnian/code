    public abstract class Base {}
    public class DerivedFirst  {}
    public class DerivedSecond {}
    
    var first  = new DerivedFirst();
    var second = new DerivedSecond(); 
    var list   = new List<Base>{first,second}
