    public interface IBase
    {
        int SomeInt { get; set; }
    }
    
    public interface ISub : IBase
    {
        int SomeOther { get; set; }
    }
    
    public class MyClass : ISub
    {
        public int SomeOther { get; set; }
        public int SomeInt { get; set; }
    }
