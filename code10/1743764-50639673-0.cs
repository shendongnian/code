    public class Parent : Ninject.IInitializable
    {
        private readonly IMessageService service;
        public Parent(IMessageService service)
        {
            this.service = service;
        }
        public void Initialize()
        {
            service.SubscribeAll(this);
        }
    }
