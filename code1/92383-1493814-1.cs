    public class SynchRequest
    {
        private ClientRequestInfo info;
        private SynchRequest(ClientRequestInfo requestInfo)
        {
            this.info = requestInfo;
        }
    
        public void Execute()
        {
            // ADDED: for example
            info.NonGenericMethod();
        }
    }
