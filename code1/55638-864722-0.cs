    public interface ISendDataService
    {
        event EventHandler<ReceivedDataEventArgs> ReceivedDataEvent;
        void SendData(Guid instanceId, IDictionary<string, object> data);
    }
    
    public class SendDataService : ISendDataService
    {
        public event EventHandler<ReceivedDataEventArgs> ReceivedDataEvent;
    
        private void OnReceivedDataEvent(Guid instanceId, IDictionary<string, object> data)
        {
            if (ReceivedDataEvent != null)
                ReceivedDataEvent(null, new ReceivedDataEventArgs(instanceId, data));
        }
    
        public void SendData(Guid instanceId, IDictionary<string, object> data)
        {
            OnReceivedDataEvent(instanceId, data);
        }
    }
    
    public class ReceivedDataEventArgs : EventArgs
    {
        public ReceivedDataEventArgs()
        {
        }
    
        public ReceivedDataEventArgs(Guid instanceId, IDictionary<string, object> data)
        {
            InstanceId = instanceId;
            Data = data;
        }
    
        public Guid InstanceId { get; set; }
        public IDictionary<string, object> Data { get; set; }
    }
