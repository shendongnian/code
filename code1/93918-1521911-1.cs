    class MyEventArgs : EventArgs
    {
        public string[] Info { get; private set; }
    
        public MyEventArgs(string[] info)
        {
            this.Info = info;
        }
    }
