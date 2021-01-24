    class PingReturnedEventArgs : EventArgs
    {
        public string Ip { get; private set; }
        public bool Online { get; private set; }
        private PingReturnedEventArgs() { }
        public PingReturnedEventArgs(string ip, bool online)
        {
            Ip = ip;
            Online = online;
        }
    }
