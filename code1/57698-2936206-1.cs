        public interface IHandler
    {
        void HandleRequest();
    }
    class Handler : IHandler
    {
        private IDataContext DataContext { get; set; }
        public Handler(IDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public void HandleRequest()
        {
            DataContext.Save("From Handler 1");
        }
    }
    class Handler2 : IHandler
    {
        private IDataContext DataContext { get; set; }
        private IHandler NextHandler { get; set; }
        public Handler2(IDataContext dataContext, IHandler handler)
        {
            DataContext = dataContext;
            NextHandler = handler;
        }
        public void HandleRequest()
        {
            if (NextHandler != null)
                NextHandler.HandleRequest();
            DataContext.Save("From Handler 2");
        }
    }
