    using (IDisposable x = new MyThing())
    {
        x.Foo();
        x.Bar();
        x.CommitChanges();
    }
    class MyThing : IDisposable
    {
        public bool IsCommitted { get; private set; }
        public void CommitChanges()
        {
            // Do stuff needed to commit.
            IsCommitted = true;
        }
        public void Dispose()
        {
            if (!IsCommitted)
                RollBack();
        }
    }
