    public class TestProxy<T> : RealProxy where T : class
    {
        public T Instance { get { return (T)GetTransparentProxy(); } }
        private readonly MarshalByRefObject refObject;
        private readonly string uri;
        public TestProxy() : base(typeof(T))
        {
            refObject = (MarshalByRefObject)Activator.CreateInstance(typeof(T));
            var objRef = RemotingServices.Marshal(refObject);
            uri = objRef.URI;
        }
        // You can find more info on what can be done in here off MSDN.
        public override IMessage Invoke(IMessage message)
        {
            Console.WriteLine("Invoke!");
            message.Properties["__Uri"] = uri;
            return ChannelServices.SyncDispatchMessage(message);
        }
    }
