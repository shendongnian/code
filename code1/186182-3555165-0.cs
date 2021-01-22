    using (new Context("block name"))
    {
        // do your staff here
    }
    
    class Context : IDisposable
    {
        public Context(string name)
        {
            // init context
        }
    
        public void Dispose()
        {
            // finish work in context
        }
    }
