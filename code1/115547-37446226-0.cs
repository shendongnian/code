    using System.IO;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    
    namespace YourProject
    {
      public static class IStreamExtensions
      {
        private const int bufferSize = 8192;
        public static MemoryStream ReadToMemoryStream(this IStream comStream)
        {
          var memoryStream = new MemoryStream();
    
          var amtRead = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(int)));
          Marshal.WriteInt32(amtRead, bufferSize);
          var buffer = new byte[bufferSize];
          while (Marshal.ReadInt32(amtRead) > 0)
          {
            comStream.Read(buffer, buffer.Length, amtRead);
            memoryStream.Write(buffer, 0, Marshal.ReadInt32(amtRead));
          }
          memoryStream.Position = 0;
    
          return memoryStream;
        }
      }
    }
