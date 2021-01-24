    public class IPAddressCompare : IComparer<IPAddress>
    {
        public int Compare(IPAddress x, IPAddress y)
        {
            var intA = BitConverter.ToUInt32(x.GetAddressBytes().Reverse().ToArray(), 0);
            var intB = BitConverter.ToUInt32(y.GetAddressBytes().Reverse().ToArray(), 0);
            return intB.CompareTo(intA);
        }
    }
