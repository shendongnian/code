services.AddHttpClient<MyServiceWrapper>("MyServiceWrapper", client =>
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
And fortunately I was able again to test myController using a mock service. :-)
