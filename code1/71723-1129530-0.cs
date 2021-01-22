    class MyType
    {
        internal EventHandler<int> _delegate;
        public event EventHandler<int> MyEvent;
        {
            add { _delegate += value; }
            remove { _delegate -= value; }
        }
    }
