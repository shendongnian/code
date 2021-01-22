    public static bool DnsTest()
        {
            try
            {
                System.Net.IPHostEntry ipHe =
                    System.Net.Dns.GetHostByName("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
