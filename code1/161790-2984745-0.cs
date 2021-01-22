    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
            out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);
        static void Main(string[] args)
        {
            ulong available;
            ulong total;
            ulong free;
            if (GetDiskFreeSpaceEx("C:\\", out available, out total, out free))
            {
                Console.Write("Total: {0}, Free: {1}\r\n", total, free);
                Console.Write("% Free: {0:F2}\r\n", 100d * free / total);
            }
            else
            {
                Console.Write("Error getting free diskspace.");
            }
            // Wait for input so the app doesn't finish right away.
            Console.ReadLine();
        }
    }
