    using System.ComponentModel;
    [DataObject]
    class MyClass
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        IEnumerable<MyObject> MyMethod()
        {
            ...
