    public class RemotingHost<T> : MarshalByRefObject where T: class
    {
        RemoteProcess host;
        T remoteObject;
        public T RemoteObject { get { return remoteObject; } }
        public RemotingAdmin()
        {
            host = new RemoteProcess();
            remoteObject = (T)host.CreateObject(typeof(T));
        }
    }
