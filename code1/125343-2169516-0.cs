    using System.Runtime.InteropServices;
    ...
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct Example {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        int[] crop;
      }
