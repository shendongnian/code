        internal static class Win32
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern bool GetDiskFreeSpaceEx(string drive, out long freeBytesForUser, out long totalBytes, out long freeBytes);
    
        }
        class Program
        {
            static void Main(string[] args)
            {
                long freeBytesForUser;
                long totalBytes;
                long freeBytes;
    
                if (Win32.GetDiskFreeSpaceEx(@"\\prime\cargohold", out freeBytesForUser, out totalBytes, out freeBytes)) {
                    Console.WriteLine(freeBytesForUser);
                    Console.WriteLine(totalBytes);
                    Console.WriteLine(freeBytes);
                }
            }
        }
