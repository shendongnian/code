    public interface IPortal
    {
      object SignIn(string name, string password);
    }
    public class Portal : MarshalByRefObject, IPortal
    {
      private object _remoteObject;
      public Portal() {
        _remoteObject = new RemoteObject();
      }
      public object SignIn(string name, string password) 
      {
        // Authorization
        // return your remote object
        return _remoteObject;
      }
    }
