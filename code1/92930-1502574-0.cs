        using System.Runtime.InteropServices;
        
        [StructLayout(LayoutKind.Sequential)]
        public struct CASH{
            public int CashNumber; 
            public CURRENCYTYPE Types[24];
        }   
        
    [ StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
        public struct CURRENCY {
             [MarshalAs( UnmanagedType.ByValTStr, SizeConst=2 )]
             public string Name;
             [MarshalAs( UnmanagedType.ByValTStr, SizeConst=6 )]
             public string NoteType;
             public int NoteNumber;
        }   
        
        class Wrapper {
            [DllImport("my.dll")]
            public static extern int GetData(ref CASH cashData}
        }
