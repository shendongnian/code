    public class EventArgs<T> : EventArgs
    {
        private T _value;
        public T Value
        {
            get { return this._value; }
            protected set { this._value = value; }
        }
        public EventArgs(T value)
        {
            this.Value = value;
        }
    }
    // ...
    public event EventHandler<EventArgs<string>> Foo;
?
