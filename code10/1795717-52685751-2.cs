    public abstract class Base {}
    public class DerivedFirst  : Base {}
    public class DerivedSecond : Base {}
    
    var first  = new DerivedFirst();
    var second = new DerivedSecond(); 
    var list   = new List<Base>{first,second}
