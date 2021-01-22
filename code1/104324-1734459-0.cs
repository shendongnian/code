    public interface IReadWrite
    {
        string SomeString { get; set; }
    }
    public interface IReadOnly
    {
        string SomeString { get; }
    }
    public class TestClass : IReadWrite, IReadOnly
    {
        public string SomeString { get; set; }
    }
