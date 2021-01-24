    interface IMyService
    {
         void MyMethod(string filter);
    }
    
    public class MyWebServiceImplementation : IMyService
    {
        public void MyMethod(string filter);
    }
    
    public class MySecondWebServiceImplementation : IMyService
    {
        public void MyMethod(string filter);
    }
    
    //Use different services from same variable
    IMyService service = new MyWebServiceImplementation();
    service.MyMethod("filter");
    service = new MySecondWebServiceImplementation();
    service.MyMethod("another filter");
