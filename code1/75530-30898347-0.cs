    /// <summary>
    /// Class for acquiring time via Ntp. Useful for applications in which correct world time must be used and the 
    /// clock on the device isn't "trusted."
    /// </summary>
    public class NtpClient
    {
        /// <summary>
        /// Contains the time returned from the Ntp request
        /// </summary>
        public class TimeReceivedEventArgs : EventArgs
        {
            public DateTime CurrentTime { get; internal set; }
        }
        /// <summary>
        /// Subscribe to this event to receive the time acquired by the NTP requests
        /// </summary>
        public event EventHandler<TimeReceivedEventArgs> TimeReceived;
        protected void OnTimeReceived(DateTime time)
        {
            if (TimeReceived != null)
            {
                TimeReceived(this, new TimeReceivedEventArgs() { CurrentTime = time });
            }
        }
        /// <summary>
        /// Not reallu used. I put this here so that I had a list of other NTP servers that could be used. I'll integrate this
        /// information later and will provide method to allow some one to choose an NTP server.
        /// </summary>
        public string[] NtpServerList = new string[]
        {
            "pool.ntp.org ",
            "asia.pool.ntp.org",
            "europe.pool.ntp.org",
            "north-america.pool.ntp.org",
            "oceania.pool.ntp.org",
            "south-america.pool.ntp.org",
            "time-a.nist.gov"
        };
        string _serverName;
        private Socket _socket;
        /// <summary>
        /// Constructor allowing an NTP server to be specified
        /// </summary>
        /// <param name="serverName">the name of the NTP server to be used</param>
        public NtpClient(string serverName)
        {
            _serverName = serverName;
        }
        /// <summary>
        /// 
        /// </summary>
        public NtpClient()
            : this("time-a.nist.gov")
        { }
        /// <summary>
        /// Begins the network communication required to retrieve the time from the NTP server
        /// </summary>
        public void RequestTime()
        {
            byte[] buffer = new byte[48];
            buffer[0] = 0x1B;
            for (var i = 1; i < buffer.Length; ++i)
                buffer[i] = 0;
            DnsEndPoint _endPoint = new DnsEndPoint(_serverName, 123);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            SocketAsyncEventArgs sArgsConnect = new SocketAsyncEventArgs() { RemoteEndPoint = _endPoint };
            sArgsConnect.Completed += (o, e) =>
            {
                if (e.SocketError == SocketError.Success)
                {
                    SocketAsyncEventArgs sArgs = new SocketAsyncEventArgs() { RemoteEndPoint = _endPoint };
                    sArgs.Completed +=
                        new EventHandler<SocketAsyncEventArgs>(sArgs_Completed);
                    sArgs.SetBuffer(buffer, 0, buffer.Length);
                    sArgs.UserToken = buffer;
                    _socket.SendAsync(sArgs);
                }
            };
            _socket.ConnectAsync(sArgsConnect);
        }
        void sArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                byte[] buffer = (byte[])e.Buffer;
                SocketAsyncEventArgs sArgs = new SocketAsyncEventArgs();
                sArgs.RemoteEndPoint = e.RemoteEndPoint;
                sArgs.SetBuffer(buffer, 0, buffer.Length);
                sArgs.Completed += (o, a) =>
                {
                    if (a.SocketError == SocketError.Success)
                    {
                        byte[] timeData = a.Buffer;
                        ulong hTime = 0;
                        ulong lTime = 0;
                        for (var i = 40; i <= 43; ++i)
                            hTime = hTime << 8 | buffer[i];
                        for (var i = 44; i <= 47; ++i)
                            lTime = lTime << 8 | buffer[i];
                        ulong milliseconds = (hTime * 1000 + (lTime * 1000) / 0x100000000L);
                        TimeSpan timeSpan =
                            TimeSpan.FromTicks((long)milliseconds * TimeSpan.TicksPerMillisecond);
                        var currentTime = new DateTime(1900, 1, 1) + timeSpan;
                        OnTimeReceived(currentTime);
                    }
                };
                _socket.ReceiveAsync(sArgs);
            }
        }
    }
