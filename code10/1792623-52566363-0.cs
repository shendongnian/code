    public class Utilities<T> : IComparable 
        where T : IComparable
        
    {
        public int CompareTo(object obj)
        {
           
        }
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
