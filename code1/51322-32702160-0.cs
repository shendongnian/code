            /// <summary>
        /// Test string for valid ip address format
        /// </summary>
        /// 
        /// <param name="Address">The ip address string</param>
        /// 
        /// <returns>Returns true if address is a valid format</returns>
        public static bool IsValidIP(IPAddress Ip)
        {
            byte[] addBytes = Ip.GetAddressBytes();
            switch (Ip.AddressFamily)
            {
                case AddressFamily.InterNetwork:
                    if (addBytes.Length == 4)
                        return true;
                    break;
                case AddressFamily.InterNetworkV6:
                    if (addBytes.Length == 16)
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }
        /// <summary>
        /// Test string for valid ip address format
        /// </summary>
        /// 
        /// <param name="Address">The ip address string</param>
        /// 
        /// <returns>Returns true if address is a valid format</returns>
        public static bool IsValidIP(string Address)
        {
            IPAddress ip;
            if (IPAddress.TryParse(Address, out ip))
            {
                switch (ip.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        if (Address.Length > 6 && Address.Contains("."))
                        {
                            string[] s = Address.Split('.');
                            if (s.Length == 4 && s[0].Length > 0 &&  s[1].Length > 0 &&  s[2].Length > 0 &&  s[3].Length > 0)
                                return true;
                        }
                        break;
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        if (Address.Contains(":") && Address.Length > 15)
                            return true;
                        break;
                    default:
                        break;
                }
            }
            return false;
        }
