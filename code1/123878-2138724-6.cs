    public class IPAddressRange
    {
        readonly AddressFamily addressFamily;
        readonly byte[] lowerBytes;
        readonly byte[] upperBytes;
        public IPAddressRange(IPAddress lowerInclusive, IPAddress upperInclusive)
        {
            // Assert that lower.AddressFamily == upper.AddressFamily
            this.addressFamily = lower.AddressFamily;
            this.lowerBytes = lowerInclusive.GetAddressBytes();
            this.upperBytes = upperInclusive.GetAddressBytes();
        }
        public bool IsInRange(IPAddress address)
        {
            if (address.AddressFamily != addressFamily)
            {
                return false;
            }
            byte[] addressBytes = address.GetAddressBytes();
            bool lowerBoundary = true, upperBoundary = true;
            for (int i = 0; i < this.lowerBytes.Length && 
                (lowerBoundary || upperBoundary); i++)
            {
                if ((lowerBoundary && addressBytes[i] < lowerBytes[i]) ||
                    (upperBoundary && addressBytes[i] > upperBytes[i]))
                {
                    return false;
                }
                lowerBoundary &= (addressBytes[i] == lowerBytes[i]);
                upperBoundary &= (addressBytes[i] == upperBytes[i]);
            }
            return true;
        }
    }
