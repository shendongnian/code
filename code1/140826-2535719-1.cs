    public static class Redirector
    {
        // PRIVATE ------------------------------------------------------------
        private const String LibraryName = "MyCpp.dll";
        [DllImport(LibraryName, CharSet = CharSet.Ansi)]
        private static extern IntPtr getCerr();
        // PUBLIC -------------------------------------------------------------
        [DllImport(LibraryName, CharSet = CharSet.Ansi)]
        public static extern bool Redirect();
        [DllImport(LibraryName, CharSet = CharSet.Ansi)]
        public static extern void Revert();
        [DllImport(LibraryName, CharSet = CharSet.Ansi)]
        internal static extern void freeCharPtr(IntPtr ptr);
        public static string GetCerr()
        {
            IntPtr temp = getCerr();
            string result = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(temp);
            freeCharPtr(temp);
            return result;
        }
    }
