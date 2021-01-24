        public static bool CheckIfServerIsAwake(string url)
        {
            var ping = new Ping();
            var reply = ping.Send(url, 60 * 1000); // 1 minute time out (in ms)
                                                            // or...
            //reply = ping.Send(new IPAddress(new byte[] { 127, 0, 0, 1 }), 3000);
            return reply.Status == IPStatus.Success;
        }
