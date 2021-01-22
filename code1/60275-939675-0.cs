    public class ThreadEventArgs : EventArgs
    {
        public ThreadEventArgs(object object)
        {
            Object = object
        }
        public object Object
        {
            get; private set;
        }
    }
