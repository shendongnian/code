    public interface IPoint<T>  
    {
        T X { get; set; }
        T Y { get; set; }
    }
    public class IntegerPoint : IPoint<int>
    {
        
        public int X { get; set; }
        public int Y { get; set; }
    }
