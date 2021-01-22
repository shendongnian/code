    using System.Runtime.InteropServices;
    class Program
    {
        [DllImport("sensapi.dll")]
        static extern bool IsNetworkAlive(out int flags);
        static void Main(string[] args)
        {
            int flags;
            bool connected = IsNetworkAlive(out flags);
        }
    }
