     public class Test1 : Test<IOhlcv, IIndexedOhlcv>
    {
        public override Func<IEnumerable<IOhlcv>, int, IIndexedOhlcv> IndexedObjectConstructor => TestMethod;        
        public IIndexedOhlcv TestMethod(IEnumerable<IOhlcv> l, int i)
        {
            return null;
        }
    }
