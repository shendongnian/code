     public abstract class ServiceBase : IService
    {
        public IBusinessContext Context { get; }
        public ServiceBase(IBusinessContext context) { Context = context; }
        public void DoSomethingFirst() {
            // common implementation here
        }
        public abstract void DoSomethingAfter();
        public virtual void DoSomething() {
            DoSomethingFirst(); 
            DoSomethingAfter();
        }
    }
