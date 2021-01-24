services.AddHttpClient<IMyServiceWrapper>("MyServiceWrapper", client =>
{
   client.BaseAddress = new Uri("http://some_service/api");
}
to
services.AddHttpClient<IMyServiceWrapper, MyServiceWrapper>("MyServiceWrapper", client =>
{
   client.BaseAddress = new Uri("http://some_service/api");
}
in order to be able to use the interface in the constructor of my controller:
public MyController(IMyServiceWrapper myService)
{
  _myService = myService;
}
Useful for testing myController using a mock service.
