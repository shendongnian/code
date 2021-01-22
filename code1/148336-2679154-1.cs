    [ProtoContract]
    class Message
    {
        private readonly List<MessageParam> parameters = new List<MessageParam>();
        [ProtoMember(1)]
        public List<MessageParam> Parameters { get { return parameters; } }
    }
    [ProtoContract]
    [ProtoInclude(3, typeof(MessageParam<int>))]
    [ProtoInclude(4, typeof(MessageParam<float>))]
    [ProtoInclude(5, typeof(MessageParam<DateTime>))]
    //...known types...
    abstract class MessageParam {
        public abstract object UntypedValue { get; set; }
        public static MessageParam<T> Create<T>(T value) {
            return new MessageParam<T> { Value = value };
        }
    }
    [ProtoContract]
    sealed class MessageParam<T> : MessageParam
    {
        [ProtoMember(1)]
        public T Value { get; set; }
        public override object UntypedValue
        {
            get { return Value; }
            set { Value = (T)value; }
        }
    }
