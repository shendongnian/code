public class MyClass {
    public string MyConst { get; protected set; }
    public MyClass() {
        MyConst = "SOMETHING";
    }
}
public class MyDerived : MyClass {
    public MyDerived() {
        MyConst = "SOMETHING ELSE";
    }
}
