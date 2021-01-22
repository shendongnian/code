    public interface IChangeable : IBasic
    {
        new int Data { set; }
    }
    public interface IBasic
    {
        int Data { get; }
    }
    class Foo : IChangeable
    {
        private int data;
        public int Data {
            get { return data; }
            set { data = value; }
        }
    }
