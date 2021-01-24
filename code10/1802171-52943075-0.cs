    class Pinger
    {
        public event EventHandler<PingReturnedEventArgs> OnPingReturned;
        public async void PingNetwork()
        {
            for (int i = 1; i <= 255; i++)
            {
                string ip = $"192.168.0.{i}";
                Ping ping = new Ping();
                try
                {
                    PingReply reply = ping.Send(IPAddress.Parse(ip));
                    TriggerEvent(reply?.Address.ToString(), true);
                }
                catch (Exception)
                {
                    TriggerEvent(ip, false);
                }
            }
        }
        private void TriggerEvent(string ip, bool online)
        {
            if (OnPingReturned == null) return;
            PingReturnedEventArgs args = new PingReturnedEventArgs(ip, online);
            OnPingReturned(this, args);
        }
    }
