    public interface IObject
    {
        string Field1 { get; }
        string Field3 { get; }
        string Field2 { get; }
    }
    class RealObject : IObject
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
    }
    class DBClass
    {
        private RealObject _object;
        public IObject GetObject()
        {
            return _object;
        }
        ...
    }
