    public class Stuff
    {
        private readonly IMyDisposableClass _client;
        public Stuff(IMyDisposableClass client)
        {
            _client = client;
        }
        public bool Foo()
        {
            using (_client)
            {
                return _client.SomeOtherMethod();
            }
        }
    }
