public class MyClass {
    public virtual MyConst { get {return "SOMETHING"; }}
}
...
public class MyDerived : MyClass {
    public virtual MyConst { get { return "SOMETHINGELSE"; }}
}
