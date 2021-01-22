    interface IBasicPropsReadable {
       int Priority { get; }
       string Name { get; }
    }
    
    interface IBasicPropsWriteable  {
       int Priority { set; }
       string Name { set; }
    }
    
    class SomeClassReadWrite : IBasicPropsReadable, IBasicPropsWriteable {
        int Priority { get; set; }
        string Name { get; set; }
    }
    class SomeClassReadOnly : IBasicPropsReadable {
        int Priority { get; }
        string Name { get; }
    }
