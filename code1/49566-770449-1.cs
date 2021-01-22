public class MyClass {
    public virtual string MyConst { get {return "SOMETHING"; }}
}
...
public class MyDerived : MyClass {
    public virtual string MyConst { get { return "SOMETHINGELSE"; }}
}
