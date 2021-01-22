    [DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
       out ulong lpFreeBytesAvailable,
       out ulong lpTotalNumberOfBytes,
       out ulong lpTotalNumberOfFreeBytes);
    
    ulong FreeBytesAvailable;
    ulong TotalNumberOfBytes;
    ulong TotalNumberOfFreeBytes;
    
    bool success = GetDiskFreeSpaceEx(@"\\mycomputer\myfolder",
                                      out FreeBytesAvailable,
                                      out TotalNumberOfBytes,
                                      out TotalNumberOfFreeBytes);
    if(!success)
        throw new System.ComponentModel.Win32Exception();
    
    Console.WriteLine("Free Bytes Available:      {0,15:D}", FreeBytesAvailable);
    Console.WriteLine("Total Number Of Bytes:     {0,15:D}", TotalNumberOfBytes);
    Console.WriteLine("Total Number Of FreeBytes: {0,15:D}", TotalNumberOfFreeBytes);
