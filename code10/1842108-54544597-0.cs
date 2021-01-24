    public class IPChecker : IIPChecker
    {
        private readonly IPAddressCollection _safeList;
        public IPChecker(IPAddressCollection safeList)
        {
            _safeList = safeList;
        }
        public bool IsSafe(IPAddress remoteIpAddress)
        {
            return _safeList.Contains(remoteIpAddress);
        }
    }
