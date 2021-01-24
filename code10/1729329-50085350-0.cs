    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(bool enable)
        {
            Enable = enable;
        }
        public bool Enable {get;}
    }
