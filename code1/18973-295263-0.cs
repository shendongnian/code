    class Foo
    {
        public event CancelEventHandler Bar;
    
        protected void OnBar()
        {
            bool cancel = false;
            CancelEventHandler handler = Bar;
            if (handler != null)
            {
                CancelEventArgs args = new CancelEventArgs(cancel);
                foreach (CancelEventHandler tmp in handler.GetInvocationList())
                {
                    tmp(this, args);
                    if (args.Cancel)
                    {
                        cancel = true;
                        break;
                    }
                }
            }
            if(!cancel) { /* ... */ }
        }
    }
