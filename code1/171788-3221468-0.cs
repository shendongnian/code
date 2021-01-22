    // Covariant parameters can be used as result types
    interface IEnumerator<out T>
    {
         T Current { get; }
    
         bool MoveNext();
    }
    
    // Covariant parameters can be used in covariant result types 
    interface IEnumerable<out T>
    {
         IEnumerator<T> GetEnumerator();
    }
    
    // Contravariant parameters can be used as argument types 
    interface IComparer<in T>
    {
         bool Compare(T x, T y); 
    }
