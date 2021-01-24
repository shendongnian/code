        private static bool DoPing()
        {
            try
            {
                using (System.Net.NetworkInformation.Ping ping = new Ping())
                {
                    PingReply result = ping.Send("8.8.8.8", 500, new byte[32], new PingOptions { DontFragment = true, Ttl = 32 });
                    if (result.Status == IPStatus.Success)
                        return true;
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
