    public interface IHandler
    {
        void Handle(Stamp stamp);
        void Handle(Letter letter);
        ...
    }
    public class Handler : IHandler
    {
        public void Handle(Stamp stamp)
        {
           // do some specific thing here...
        }
        public void Handle(Letter letter)
        {
           // do some specific thing here...
        }
        ...
    }
    public interface IProduct
    {
        string Name { get; }
        int Quantity { get; set; }
        float Amount { get; }
        void Handle(IHandler handler);
    }
    public class Stamp : IProduct
    {
        public string Name { get { return "Stamp"; } }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public float UnitPrice { get; set; }
        public void Handle(IHandler handler)
        {
             handler.Handle(this);
        }
    }
