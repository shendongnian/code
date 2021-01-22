    using System.Net.NetworkInformation;
        NetworkInterface[] niAdpaters = NetworkInterface.GetAllNetworkInterfaces();
        private Boolean GetDhcp(Int32 iSelectedAdpater)
        {
            if (niAdpaters[iSelectedAdpater].GetIPProperties().GetIPv4Properties() != null)
            {
                return niAdpaters[iSelectedAdpater].GetIPProperties().GetIPv4Properties().IsDhcpEnabled;
            }
            else
            {
                return false;
            }
        }
