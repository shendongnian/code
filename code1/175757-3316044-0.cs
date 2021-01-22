    interface IContact<T>
    {
        T Id { get; }
    }
    
    public class Contact : IContact<int>
    {
        public int Id { get; private set; }
    }
    
    public class InternalContact : IContact<string>
    {
        public string Id { get; private set; }
    }
