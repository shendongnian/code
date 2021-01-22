    public interface Foo<out T> { }
    public class Bar<T> : Foo<T> { }
    
    interface MyInterface { }
    public class MyBase : MyInterface { }
    
    Foo<MyBase> a = new Bar<MyBase>();
    Foo<MyInterface> b = a;
