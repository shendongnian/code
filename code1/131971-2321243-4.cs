    interface IMsgVisitor<T>
    {
        T Visit(Add msg);
        T Visit(Sub msg);
        T Visit(Query msg);
    }
    
    abstract class Msg
    {
        public abstract T Accept<T>(IMsgVistor<T> visitor)
    }
    
    class Add : Msg
    {
        public readonly int Value;
        public Add(int value) { this.Value = value; }
        public override T Accept<T>(IMsgVisitor<T> visitor) { return visitor.Visit(this); }
    }
    
    class Sub : Msg
    {
        public readonly int Value;
        public Add(int value) { this.Value = value; }
        public override T Accept<T>(IMsgVisitor<T> visitor) { return visitor.Visit(this); }
    }
    
    class Query : Msg
    {
        public readonly ReplyChannel<int> Value;
        public Add(ReplyChannel<int> value) { this.Value = value; }
        public override T Accept<T>(IMsgVisitor<T> visitor) { return visitor.Visit(this); }
    }
