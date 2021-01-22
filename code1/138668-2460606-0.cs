    public class CurrentSelector<T> : INodeFetcher<T>
    {
        public List<T> GetNodes(int argument) 
        {
        // Return the result "current" method
        }
    }
    public class LegacySelector<T> : INodeFetcher<T>
    {
        public List<T> GetNodes(int argument) 
        {
        // Return the result "legacy" method
        }
    }
