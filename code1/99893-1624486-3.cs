    public interface IChangeable : IBasic
    {
        new int Data { get;  set; }
    }
    class Foo : IChangeable
    {
        private int value;
        int IBasic.Data { get { return value; } }
        int IChangeable.Data { set { this.value = value; } get {return value; } }
    }
