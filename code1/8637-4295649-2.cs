    TestService svc = new TestService();
    svc.SomeEvent += new MyEventHandler(receivingObject.OnSomeEvent);
    ServiceHost host = new ServiceHost(svc);
    host.Open();
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)] // so that a single service instance is created
        public class TestService : ITestService
        {
            public event MyEventHandler SomeEvent;
            ...
            ...
        }
