    public interface ISerialPortWatcher
    {
        event EventHandler<ReceivedDataEventArgs> ReceivedData;
        event EventHandler StartedListening;
        event EventHandler StoppedListening;
        SerialPortSettings PortOptions { set; }
        bool Listening { get; set; }
        void Stop();
        void Start();
    }
    public class ReceivedDataEventArgs : EventArgs
    {
        public ReceivedDataEventArgs(string data)
        {
            Data = data;
        }
        public string Data { get; private set; }
    }
