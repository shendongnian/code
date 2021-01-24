    internal class DemoWtsListenerCallback : IWTSListenerCallback
    {
        public void OnNewChannelConnection(
            IWTSVirtualChannel pChannel, 
            [MarshalAs(UnmanagedType.BStr)] string data, 
            [MarshalAs(UnmanagedType.Bool)] out bool pAccept, 
            out IWTSVirtualChannelCallback pCallback)
        {
            pAccept = true;
            pCallback = new DemoWtsChannelCallback(pChannel);
        }
    }
