    const uint GENERIC_READ = 0x80000000;
    const uint GENERIC_WRITE = 0x40000000;
    const int FILE_SHARE_READ = 0x1;
    const int FILE_SHARE_WRITE = 0x2;
    const uint FILE_FLAG_WRITE_THROUGH = 0x80000000;
    const uint FILE_FLAG_NO_BUFFERING = 0x20000000;
    const uint IOCTL_DISK_SET_DISK_ATTRIBUTES = 0x0007c0f4;
    const ulong DISK_ATTRIBUTE_READ_ONLY = 0x0000000000000002;
    const uint IOCTL_DISK_UPDATE_PROPERTIES = 459072;
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern IntPtr CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr SecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile
    );
    [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool DeviceIoControl(
       IntPtr hDevice,
       uint dwIoControlCode,
       IntPtr lpInBuffer,
       uint nInBufferSize,
       IntPtr lpOutBuffer,
       uint nOutBufferSize,
       out uint lpBytesReturned,
       IntPtr lpOverlapped
    );
    struct SET_DISK_ATTRIBUTES
    {
       public uint Version;
       [MarshalAs(UnmanagedType.I1)]
       public bool Persist;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
       public byte[] Reserved1;
       public ulong Attributes;
       public ulong AttributesMask;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
       public uint[] Reserved2;
    };
    public IntPtr CreateHandle(string driveLetter)
    {
       string filename = @"\\.\" + driveLetter[0] + ":";
       return CreateFile(filename, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, 0x3, FILE_FLAG_WRITE_THROUGH, IntPtr.Zero);
    }
    private void SetReadonly(IntPtr handle)
    {
       var sda = new SET_DISK_ATTRIBUTES();
       sda.Persist = true;
       sda.AttributesMask = DISK_ATTRIBUTE_READ_ONLY;
       sda.Attributes = DISK_ATTRIBUTE_READ_ONLY;
       sda.Reserved1 = new byte[3] { 0, 0, 0 };
       sda.Reserved2 = new uint[4] { 0, 0, 0, 0 };
       int nPtrQryBytes = Marshal.SizeOf(sda);
       sda.Version = (uint)nPtrQryBytes;
       IntPtr ptrQuery = Marshal.AllocHGlobal(nPtrQryBytes);
       Marshal.StructureToPtr(sda, ptrQuery, false);
       uint byteReturned;
       bool res = DeviceIoControl(handle, IOCTL_DISK_SET_DISK_ATTRIBUTES, ptrQuery, (uint)nPtrQryBytes, IntPtr.Zero, 0, out byteReturned, IntPtr.Zero);
       bool res2 = DeviceIoControl(handle, IOCTL_DISK_UPDATE_PROPERTIES, IntPtr.Zero, 0, IntPtr.Zero, 0, out byteReturned, IntPtr.Zero);
       var mess = new List<string>();
       mess.Add(new Win32Exception(Marshal.GetLastWin32Error()).Message);
       mess.Add(new Win32Exception(Marshal.GetLastWin32Error()).Message);
       MessageBox.Show(string.Join(" ", mess));
    }
    private void button1_Click(object sender, EventArgs e)
    {
       SetReadonly(CreateHandle(textBox1.Text));
    }
