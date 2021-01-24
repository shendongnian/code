    public class TransformEnumerator<TSource, TTarget> : IEnumerator<TTarget>
    {
        IEnumerator<TSource> SourceEnumerator;
        Func<TSource, TTarget> TransformFunc;
    
        public TransformEnumerator(IEnumerator<TSource> sourceEnumerator, Func<TSource, TTarget> transformFunc)
        {
            SourceEnumerator = sourceEnumerator;
            TransformFunc = transformFunc;
        }
    
        public TTarget Current => TransformFunc(SourceEnumerator.Current);
    
        object IEnumerator.Current => TransformFunc(SourceEnumerator.Current);
    
        public void Dispose()
        {
            SourceEnumerator.Dispose();
        }
    
        public bool MoveNext()
        {
            return SourceEnumerator.MoveNext();
        }
    
        public void Reset()
        {
            SourceEnumerator.Reset();
        }
    }
    
