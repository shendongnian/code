      [DllImport(@".\IFDLL.dll", EntryPoint = "GetProgramFileList")]
      public static extern int GetProgramFileListTest(uint proNum, ref PROFILE_INFO pro);
    
      [StructLayout(LayoutKind.Sequential)]
      public struct PROFILE_INFO
      {
          public PROINFO proInfo;            // WNo/name/type
          public long proSize;               // Program size
          public PROGRAM_DATE createDate;    // Program creating date
          public PROGRAM_DATE writeDate;     // Program updating date
      }
    
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PROINFO
      {
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)] public string wno;         // WNo.
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)] private string dummy;       // dummy
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 49)] public string comment;     // program name
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)] private string dummy2;      // dummy
          public char type;                                                               // program type
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)] private string dummy3;      // dummy
      }
    
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct PROGRAM_DATE
      {
          public short year;                 // Date (Year) 4-digit
          public char month;                 // Date (Month)
          public char day;                   // Date (Day)
          public char hour;                  // Date (Time)
          public char min;                   // Date (Minutes)
          [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)] private string dummy; // Dummy
      }
