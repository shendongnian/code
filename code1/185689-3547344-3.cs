    public class Example
    {
        // Number of pings that can be pending at the same time
        private const int InitalRequests = 10000;
        // variables from your Main method
        private Oyster.Math.IntX _omiFromIP = 0;
        private Oyster.Math.IntX _omiToIP = 0;
        private Oyster.Math.IntX _omiCurrentIp = 0;
        // synchronoize so that two threads
        // cannot ping the same IP.
        private object _syncLock = new object();
        static void Main(string[] args)
        {
            string strFromIP = "192.168.0.1";
            string strToIP = "192.168.255.255";
            IsValidIP(strFromIP, ref _omiFromIP);
            IsValidIP(strToIP, ref _omiToIP);
            for (_omiCurrentIp = _omiFromIP; _omiCurrentIp <= _omiFromIP + InitalRequests; ++_omiCurrentIp)
            {
                Console.WriteLine(IPn2IPv4(_omiCurrentIp));
                System.Net.IPAddress sniIPaddress = System.Net.IPAddress.Parse(IPn2IPv4(_omiCurrentIp));
                SendPingAsync(sniIPaddress);
            }
            Console.WriteLine(" --- Press any key to continue --- ");
            Console.ReadKey();
        } // Main
        // http://pberblog.com/post/2009/07/21/Multithreaded-ping-sweeping-in-VBnet.aspx
        // http://www.cyberciti.biz/faq/how-can-ipv6-address-used-with-webbrowser/#comments
        // http://www.kloth.net/services/iplocate.php
        // http://bytes.com/topic/php/answers/829679-convert-ipv4-ipv6
        // http://stackoverflow.com/questions/1434342/ping-class-sendasync-help
        public void SendPingAsync(System.Net.IPAddress sniIPaddress)
        {
            int iTimeout = 5000;
            System.Net.NetworkInformation.Ping myPing = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions parmPing = new System.Net.NetworkInformation.PingOptions();
            System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent(false);
            myPing.PingCompleted += new System.Net.NetworkInformation.PingCompletedEventHandler(AsyncPingCompleted);
            string data = "ABC";
            byte[] dataBuffer = Encoding.ASCII.GetBytes(data);
            parmPing.DontFragment = true;
            parmPing.Ttl = 32;
            myPing.SendAsync(sniIPaddress, iTimeout, dataBuffer, parmPing, waiter);
            //waiter.WaitOne();
        }
        private void AsyncPingCompleted(Object sender, System.Net.NetworkInformation.PingCompletedEventArgs e)
        {
            System.Net.NetworkInformation.PingReply reply = e.Reply;
            ((System.Threading.AutoResetEvent)e.UserState).Set();
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("Roundtrip time: {0}", reply.RoundtripTime);
            }
            // Keep starting those async pings until all ips have been invoked.
            lock (_syncLock)
            {
                if (_omiToIP < _omiCurrentIp)
                {
                    ++_omiCurrentIp;
                    System.Net.IPAddress sniIPaddress = System.Net.IPAddress.Parse(IPn2IPv4(_omiCurrentIp));
                    SendPingAsync(sniIPaddress);
                }
            }
        }        
    }
