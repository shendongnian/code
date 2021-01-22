        using System.Collections.Generic;
        using System.Net.NetworkInformation;
        using System.Text;
        using System.Net;
        ...
        public static void TraceRoute(string hostNameOrAddress)
        {
            for (int i = 1; i < 20; i++)
            {
                IPAddress ip = GetTraceRoute(hostNameOrAddress, i);
                if(ip == null)
                {
                    break;
                }
                Console.WriteLine(ip.ToString());
            }
        }
        private static IPAddress GetTraceRoute(string hostNameOrAddress, int ttl)
        {
            const string Data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Ping pinger = new Ping();
            PingOptions pingerOptions = new PingOptions(ttl, true);
            int timeout = 10000;
            byte[] buffer = Encoding.ASCII.GetBytes(Data);
            PingReply reply = default(PingReply);
            reply = pinger.Send(hostNameOrAddress, timeout, buffer, pingerOptions);
            List<IPAddress> result = new List<IPAddress>();
            if (reply.Status == IPStatus.Success || reply.Status == IPStatus.TtlExpired)
            {
                return reply.Address;
            }
            else
            {
                return null;
            }
        }
