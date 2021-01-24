    public interface IFoo {
        IBar TheProperty { get; set; }
    }
    public interface IBar {
        IEnumerable<MyType> GetTheValues();
    }
    public class MyType { }
