    public interface IMyInterface
    {
        string Name { get; set; }
    }
    public class MyClass : IMyInterface
    {
        string IMyInterface.Name { get; set; }
    }
