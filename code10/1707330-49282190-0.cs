    using NETWORKLIST;
    public class Foo : INetworkListManagerEvents 
    {
        private NetworkListManager nlm; 
        private IConnectionPoint icp;
        private int cookie = 0;
        
        public Foo()
        {
            nlm = new NetworkListManager();
            IConnectionPointContainer icpc = (IConnectionPointContainer)nlm;
            Guid tempGuid = typeof(INetworkListManagerEvents).GUID;
            icpc.FindConnectionPoint(ref tempGuid, out icp);
            icp.Advise(this, out cookie);
        }
        
        //this method must be implemented
        public void ConnectivityChanged(NLM_CONNECTIVITY newConnectivity)
        {
            //Your code goes here
        }
    }
