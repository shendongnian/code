    public class Vector<T>
    {
        public T x { get; }
        public T y { get; }
    }
    public class VectorWithOperators<TVector, T> : Vector<T> 
       where TVector : Vector<T>, new()
    {
        public TVector GetSomeResult()
        {
            return new TVector();
        }
    }
    public class Force3D : VectorWithOperators<Force3D, double>
    {
    }
