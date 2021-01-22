    public sealed class NetLog
    {
        public delegate void MessageEventHandler(object sender, MessageEventArgs args);
        public static event MessageEventHandler OnMessageFired;
        public static void FireMessage(Object obj,MessageEventArgs eventArgs)
        {
            if (OnMessageFired != null)
            {
                OnMessageFired(obj, eventArgs);
            }
        }
    }
    public class MessageEventArgs : EventArgs
    {
        public string ItemUri { get; private set; }
        public Operation Operation { get; private set; }
        public Status Status { get; private set; }
        public MessageEventArgs(string itemUri, Operation operation, Status status)
        {
            ItemUri = itemUri;
            Operation = operation;
            Status = status;
        }
    }
    public enum Operation
    {
        Upload,Download
    }
    public enum Status
    {
        Started,Finished
    }
