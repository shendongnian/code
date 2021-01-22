        public const int MAX_ICE_MS_TRACK_LENGTH = 256;
        [StructLayout(LayoutKind.Sequential)]
        public struct TRACKDATA
        {  
            public UInt32 nLength;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szTrackData;
        }
		
		
        [DllImport("ICE_API.dll", EntryPoint="_ReadMagstripe@20", CharSet=CharSet.Auto, 
            CallingConvention=CallingConvention.Winapi, SetLastError=true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadMagstripe(int hdc, ref TRACKDATA ptrack1, ref TRACKDATA ptrack2,
             ref TRACKDATA ptrack3, ref TRACKDATA reserved);
        [DllImport("ICE_API.dll", EntryPoint="_EncodeMagstripe@20", CharSet=CharSet.Auto,
            CallingConvention = CallingConvention.Winapi, SetLastError=true)]
        public static extern bool EncodeMagstripe(int hdc, [In] ref TRACKDATA ptrack1, [In] ref TRACKDATA ptrack2,
            [In] ref TRACKDATA ptrack3, [In] ref TRACKDATA reserved);
			
    /*
  			....
    */
			
		private void EncodeMagstripe()
        {
            ICE_API.TRACKDATA track1Data = new ICE_API.TRACKDATA();
            ICE_API.TRACKDATA track2Data = new ICE_API.TRACKDATA();
            ICE_API.TRACKDATA track3Data = new ICE_API.TRACKDATA();
            ICE_API.TRACKDATA reserved = new ICE_API.TRACKDATA();
            //if read magstripe
            bool bRes = ICE_API.ReadMagstripe(printer.Hdc, ref track1Data, ref track2Data,
                ref track3Data, ref reserved);
            //encode magstripe
            if (bRes)
            {
                track2Data.szTrackData = "1234567890";
                track2Data.nLength = 10;
                bRes = ICE_API.EncodeMagstripe(printer.Hdc, ref track1Data, ref track2Data, ref track3Data, ref reserved);
            }
        }
