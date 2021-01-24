    public interface ICollection<T> where T : IObject
    {
        T[] Values { get; set; }
    }
    public class Collection : ICollection<SecondObject>
    {
        public SecondObject[] Values { get; set; }
    }
