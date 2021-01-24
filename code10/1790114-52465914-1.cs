    public class IPAddressCompare : IComparer<IPAddress>
    {
        public int Compare(IPAddress x, IPAddress y)
        {
            var lngA = BitConverter.ToUInt32(x.GetAddressBytes().Reverse().ToArray(), 0);
            var lngB = BitConverter.ToUInt32(y.GetAddressBytes().Reverse().ToArray(), 0);
            return lngB.CompareTo(lngA);
        }
    }
