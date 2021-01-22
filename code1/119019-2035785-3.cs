      [DllImport("kernel32.dll", SetLastError=true)]
      static extern bool ReadFile(HandleRef hFile, byte[] lpBuffer,
         uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);
      private static HandleRef getHandle()
      {
         FileStream fs = new FileStream("myfile", FileMode.OpenOrCreate, FileAccess.ReadWrite);
         return new HandleRef(fs, fs.SafeFileHandle.DangerousGetHandle());
      }
      private static void Main()
      {
         HandleRef intPtr = getHandle();
         GC.Collect();
         GC.WaitForPendingFinalizers();
         GC.Collect();
         System.Threading.Thread.Sleep(1000);
         const uint BYTES_TO_READ = 10;
         byte[] buffer = new byte[BYTES_TO_READ];
         uint bytes_read = 0;        
         bool read_ok = ReadFile(intPtr, buffer, BYTES_TO_READ, out bytes_read, IntPtr.Zero);
         if (!read_ok)
         {
            Win32Exception ex = new Win32Exception();
            string errMsg = ex.Message;
         }
      }
