    class MyClass
    {
    }
    class Derived : MyClass, IList<MyClass>
    {
        // ...
    }
    // ...
    // Here IList<MyClass> is Derived, which is valid because Derived implements IList<MyClass>
    IEnumerable<IList<MyClass>> myData = new []{new Derived()};
    // Here MyClass is Derived, which is valid because Derived inherits from MyClass
    foreach (MyClass o in myData)
    {
        // do something
    }
