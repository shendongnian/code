    public class SomeClass
    {
        public IIndexerResult this[int index]    
        {
            get { return new IndexerResult(); } //This is perfectly fine!
        }
    }
    internal class IndexerResult : IIndexerResult
    {
        //Some code
    }
    public interface IIndexerResult
    {
    }
