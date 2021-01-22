    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 4)]
    public struct TC_INI_TYPE
    {
       public short wCardNo;
       public short wCardType;
       public short wConnect;
       public short wIRQ;
       [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 32)] // change 32 to LEN_FILEPATH
       public char[] cbDir;
       [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 32)] // change 32 to MAX_CARD_NO
       public short[] wAddress;
       public short wMajorVer;
       public short wMinorVer;
       [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 32)] // change 32 to MAX_CHANNEL_NO
       public short[] wChType;
    }
