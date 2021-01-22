    class Program
    {
        static void Main(string[] args)
        {
            PingReply reply = null;
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            Ping p = new Ping();
            for (int n = 1; n < 255 && (reply == null || reply.Status != IPStatus.Success); n++)
            {
                options.Ttl = n;
                reply = p.Send("www.yahoo.com", 1000, new byte[1], options);
                if (reply.Address != null)
                    Console.WriteLine(n.ToString() + " : " + reply.Address.ToString());
                else
                    Console.WriteLine(n.ToString() + " : <null>");
            }
            Console.WriteLine("Done.");
            System.Console.ReadKey();
        }
    }
