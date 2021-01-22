    public interface IServiceClass
    {
        void DoService();
    }
    class ServiceClass : IServiceClass
    {
        private IHandler Handler { get; set; }
        public ServiceClass(IHandler handler)
        {
            Handler = handler;
        }
        public void DoService()
        {
            Handler.HandleRequest();
        }
    }
