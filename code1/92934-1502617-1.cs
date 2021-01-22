    using System;
    using System.Runtime.InteropServices;
    
    public static class MyCApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct CASHTYPE
        {
            public int CashNumber;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
            public CURRENCYTYPE[] Types;
        }
    
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct CURRENCYTYPE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
            public string Name;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string NoteType;
            public int NoteNumber;
        }
    
        [DllImport("MyCApi.dll")]
        public static extern int GetData(ref CASHTYPE cashData);
    }
