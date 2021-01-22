    public class ServiceAdapter: IServiceAdapter
    {
        public void CallSomeWebMethod()
        {
            var someService = new MyWebService();
            someService.SomeWebMethod();
        }
    }
