    public static void MyCustomExtensionMethod(this Foo foo) { }
    ...
    public class Bar() : Foo
    {
       // I did not create Foo and do not have access to Foo
       this.MyCustomExtensionMethod();
    }
