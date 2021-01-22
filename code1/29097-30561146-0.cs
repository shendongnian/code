    public static class IPAddressExtensions
    {
        /// <summary>
        /// Converts IPv4 and IPv4 mapped to IPv6 addresses to an unsigned integer.
        /// </summary>
        /// <param name="address">The address to conver</param>
        /// <returns>An unsigned integer that represents an IPv4 address.</returns>
        public static uint ToUint(this IPAddress address)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork || address.IsIPv4MappedToIPv6)
            {
                var bytes = address.GetAddressBytes();
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytes);
                return BitConverter.ToUInt32(bytes, 0);
            }
            throw new ArgumentOutOfRangeException("address", "Address must be IPv4 or IPv4 mapped to IPv6");
        }
    }
