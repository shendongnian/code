    class A
    {
       public double Stock { get; }
    
       // Processing and cloning actually works using these InternalA's
       internal InternalA ConvertToInternal() {}
    }
    
    internal class InternalA : ICloneable
    {
       public double Stock { get; set; }
    
       public bool HasSufficientStock() {}
    }
