    public interface IMyShape<T>
    {
       T X { get; }
       T Y { get; }
    }
    
    public class IntSquare : IMyShape<int>
    {
       int X { get { return 100; } }
       int Y { get { return 100; } }
    }
    
    public class IntTriangle : IMyShape<int>
    {
       int X { get { return 200; } }
       int Y { get { return 200; } }
    }
    
    public class FloatSquare : IMyShape<float>
    {
       float X { get { return 100.05; } }
       float Y { get { return 100.05; } }
    }
