    public class Smoothie<T> : ISmoothie<T> where T : IFruit
    {
       // Generic Fruit Smoothie
       public T Type { get; set; } // we can do this
    }
    
    public interface ISmoothie<out T> where T : IFruit
    {
       T Type { get; set; } // compiler error CS1961 Invalid variance: 
    }
