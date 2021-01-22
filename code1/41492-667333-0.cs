    public const int MAX_ICE_MS_TRACK_LENGTH = 256;
    [StructLayout(LayoutKind.Sequential)]
    public class MSTrackData {
        public UInt32 nLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public Byte[] TrackData = new byte[MAX_ICE_MS_TRACK_LENGTH];
    }
    [DllImport("ICE_API.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EncodeMagstripe(IntPtr hDC,
                    [In] MSTrackData pTrack1,
                    [In] MSTrackData pTrack2,
                    [In] MSTrackData pTrack3,
                    [In] MSTrackData reserved);
