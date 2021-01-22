    public interface IMyWebService
    {
        string DoSomething ();
    }
    public class MyWebServiceWrapper : IMyWebService
    {
        public string DoSomething () 
        {
            MyWebService client = new MyWebService ();
            client.DoSomething ();
        }
    }
    public class MyClient
    {
        private readonly IMyWebService _client = null;
        public MyClient () : this (new MyWebService ()) { }
        public MyClient (IMyWebService client)
        {
            _client = client;
        }
        public void CallService ()
        {
            _client.DoSomething ();
        }
    }
