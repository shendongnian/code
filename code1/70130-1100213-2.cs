    @WebService
    class BusinessProcess implements IBusinessProcess
    {
       public HelloWorldObject helloWorld()
       {
          return new HelloWorldObject("Earth");
       }
    }
