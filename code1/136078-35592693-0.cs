    public class MarshalByRefObjectPermanent : MarshalByRefObject
    {
        public override object InitializeLifetimeService()
        {
            return null;
        }
        ~MarshalByRefObjectPermanent()
        {
            RemotingServices.Disconnect(this);
        }
    }
