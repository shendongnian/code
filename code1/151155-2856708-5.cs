     public static class Parser
     {
        public delegate void DlgDumpTipData(IntPtr a, int len);
        [DllImport("C++ dll name here", EntryPoint = "AttachCallback", ExactSpelling = true)]
        public static extern void AttachCallback(DlgDumpTipData callback); 
        
        public static int ConnectAndStartReceive(...)
        {
           // Attach a callback function (called when a message is received from data feed)
           AttachCallback(DumpDataCalback);
           ...
        }
        public delegate void MsgHandler(string msg);
        // When data arrives from the C library, this event passes it on to C# clients 
        public static event MsgHandler OnMessageArrived = delegate { };
        public static void DumpDataCalback(IntPtr ptr, int len)
        {
           //string str = Marshal.PtrToStringAnsi(ptr); 
           string dumpData;
           sbyte[] byteArr = new sbyte[len];
           for (int i = 0; i < len; i++)
           {
              // WARNING: if byte > 127 we have a problem when casting from Byte to SByte
              // In this case there is no problem, tested with values over 127 and it
              // converts fine to Latin-1 using the String overload 
              byteArr[i] = (sbyte)Marshal.ReadByte(ptr, i); 
           }
           unsafe
           {
             fixed (sbyte* pbyteArr = byteArr) // Instruct the GC not to move the memory
             {
                 dumpData = new String(pbyteArr, 0, len, Encoding.GetEncoding("ISO-8859-1"));
             }
           }
 
           // Send data to whoever subscribes to it
           OnMessageArrived(dumpData);
           GC.Collect(); // This slows things down but keeps the memory usage low
        }        
     }
