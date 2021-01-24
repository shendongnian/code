    public static class IntPtrExtensions
    {
        // I'm lazy
        public static T ToStruct<T>(this IntPtr ptr)
            => (T)Marshal.PtrToStructure(ptr, typeof(T));
    }
    public static class RemoteControlPlugin
    {
        [DllImport("path/to/remoteplugin.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetServerPluginInterface();
        private static RemoteServerPluginI? _instance = null;
        public static RemoteServerPluginI Instance =>
            (RemoteServerPluginI)(
                _instance ??
                (_instance = GetServerPluginInterface().ToStruct<RemoteServerPluginI>())
            );
    }
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var remoteServer = RemoteControlPlugin.Instance;
            Console.WriteLine(remoteServer.GetVersion());  // Easy!
        }
    }
