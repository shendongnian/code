    public class Callbacks
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnRemoteConnectionRequestDelegate(IntPtr caller, [MarshalAs(UnmanagedType.LPWStr)]string ip, ref int accept);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void StartServerDelegate();
        private IntPtr ptr;
        public static implicit operator Callbacks(IntPtr ptr)
        {
            return new Callbacks(ptr);
        }
        public Callbacks(IntPtr ptr)
        {
            this.ptr = ptr;
            {
                IntPtr del = Marshal.ReadIntPtr(ptr, 0);
                if (del != IntPtr.Zero)
                {
                    remoteConnectionRequest = Marshal.GetDelegateForFunctionPointer<OnRemoteConnectionRequestDelegate>(del);
                }
            }
            {
                IntPtr del = Marshal.ReadIntPtr(ptr, IntPtr.Size);
                if (del != IntPtr.Zero)
                {
                    startServer = Marshal.GetDelegateForFunctionPointer<StartServerDelegate>(del);
                }
            }
        }
        private OnRemoteConnectionRequestDelegate remoteConnectionRequest;
        private StartServerDelegate startServer;
        public OnRemoteConnectionRequestDelegate RemoteConnectionRequest
        {
            get => remoteConnectionRequest;
            set
            {
                if (value != remoteConnectionRequest)
                {
                    remoteConnectionRequest = value;
                    Marshal.WriteIntPtr(ptr, 0, remoteConnectionRequest != null ? Marshal.GetFunctionPointerForDelegate(remoteConnectionRequest) : IntPtr.Zero);
                }
            }
        }
        public StartServerDelegate StartServer
        {
            get => startServer;
            set
            {
                if (value != startServer)
                {
                    startServer = value;
                    Marshal.WriteIntPtr(ptr, IntPtr.Size, startServer != null ? Marshal.GetFunctionPointerForDelegate(startServer) : IntPtr.Zero);
                }
            }
        }
    }
