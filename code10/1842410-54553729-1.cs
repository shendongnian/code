    public interface IMerge<T>
    {
        byte[] Process(List<T> req);
    }
    public class Merge<T> : IMerge<T>
    {
        public byte[] Process(List<T> req)
        {
            // processing
        }
    }
    
