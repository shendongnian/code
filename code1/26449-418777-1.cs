    public class Bar<T> where T : IFoo, new
    {
        public Bar(T t)
        {
        }
    
        public Bar()
            : this(new T()) 
        {
        }
    }
