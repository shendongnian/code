    class Program
    {
        private static void Main(string[] args)
        {
            bool isNetworkCableConnected = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        } 
    }
