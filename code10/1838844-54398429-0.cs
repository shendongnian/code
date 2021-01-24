    public abstract class Test<TInput, TIndexed>
        {
            public abstract Func<IEnumerable<TInput>, int, TIndexed> IndexedObjectConstructor { get; }
        }
    
        public class Test1 : Test<IOhlcv, IIndexedOhlcv>
        {
            public override Func<IEnumerable<IOhlcv>, int, IIndexedOhlcv> IndexedObjectConstructor
            {
                get
                {
                    return TestMethod;                
                }
            }
    
            public IIndexedOhlcv TestMethod(IEnumerable<IOhlcv> l, int i)
            {
                return null;
            }
        }
    
        public interface IOhlcv
        {
    
        }
    
        public interface IIndexedOhlcv
        {
    
        }
