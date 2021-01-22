    public interface IFoo { }
    public class Bar : IFoo { }
    public class Zed : IFoo { }
    
    //.....
    
    List<IFoo> myList = new List<Bar>(); // makes sense so far
    
    myList.Add(new Bar()); // OK, since Bar implements IFoo
    myList.Add(new Zed()); // aaah! Now we see why.
    
    //.....
