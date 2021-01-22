    class Foo
    {
        private EventHandler _bar;
        public event EventHandler Bar
        {
            add
            {
                if (_bar != null || value.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Only one handler allowed");
                }
                _bar = (EventHandler)Delegate.Combine(_bar, value);
            }
            remove
            {
                _bar = (EventHandler)Delegate.Remove(_bar, value);
            }
        }
    }
