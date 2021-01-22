    abstract class MessageBase
    {
        protected abstract bool Check();
    }
    class NewClass : MessageBase
    {
        protected override bool Check() { ... }
    }
