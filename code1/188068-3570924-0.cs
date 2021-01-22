    public interface IBase
    {
       int MyProperty { get; }
    }
    
    public interface IDerive : IBase
    {
        // you need to specify the getter here too
        new int MyProperty { get; set; }
    }
