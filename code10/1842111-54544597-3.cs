    public class IPChecker : IIPChecker
    {
        private readonly IPAddress[] _safeList;
        public IPChecker(string safeList)
        {
            var _safeList = safeList
                .Split(';')
                .Select(IPAddress.Parse)
                .ToArray();
        }
        public bool IsSafe(IPAddress remoteIpAddress)
        {
            return _safeList.Contains(remoteIpAddress);
        }
    }
