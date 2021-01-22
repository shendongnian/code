    interface IFoo
    {
        event EventHandler OnChanged;
    }
    class MyClass : IFoo
    {
        public event EventHandler OnChanged;
        private FireOnChanged()
        {
            EventHandler handler = this.OnChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty); // with appropriate args, of course...
            }
        }
    }
