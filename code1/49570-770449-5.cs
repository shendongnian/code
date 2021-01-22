public class MyClass {
    public virtual string MyConst { get {return "SOMETHING"; }}
}
...
public class MyDerived : MyClass {
    public override string MyConst { get { return "SOMETHINGELSE"; }}
}
