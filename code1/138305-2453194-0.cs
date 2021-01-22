    public interface ILeftRight
    {
        int Right { get;}
        int Left { get; }
    }
    public class NSM<X, U, V> where U : IQueryable<X> where X : ILeftRight where V : new()  
    {
        private readonly U _src;
        public NSM(U source) { _src = source; }
        public IQueryable<V> LeafNodes
        {
            get
            {
                //return from s in _src where (s.Right - 1 == s.Left) select new V();
                Expression< Func< X, V > > expression = s => new V();
                return _src.Where( s => s.Right - 1 == s.Left ).Select( expression );
            }
        }
    }
