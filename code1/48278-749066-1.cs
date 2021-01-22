    class BaseClass<T>
    {
        public T property { get; set; }
    }
    
    class GenericClass<T> : BaseClass<T>
    { 
            
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericClass<int> l = new GenericClass<int>();
            l.property = 10;
        }
    }
