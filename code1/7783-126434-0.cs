    internal class B : IB
    {
        private string someData;
    
        public string SomeData
        {
            get { return someData; }
            set { someData = value; }
        }
    }
    
    public interface IB
    {
        string SomeData { get; }
    }
