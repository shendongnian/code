    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput, 
          CharInfo[] lpBuffer, 
          Coord dwBufferSize, 
          Coord dwBufferCoord, 
          ref SmallRect lpWriteRegion);
    
        [StructLayout(LayoutKind.Sequential)]
        public struct Coord
        {
          public short X;
          public short Y;
    
          public Coord(short X, short Y)
          {
            this.X = X;
            this.Y = Y;
          }
        };
    
        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
          [FieldOffset(0)] public char UnicodeChar;
          [FieldOffset(0)] public byte AsciiChar;
        }
    
        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
          [FieldOffset(0)] public CharUnion Char;
          [FieldOffset(2)] public short Attributes;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
          public short Left;
          public short Top;
          public short Right;
          public short Bottom;
        }
    
    
        [STAThread]
        static void Main(string[] args)
        {
          SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
    
          if (!h.IsInvalid)
          {
            CharInfo[] buf = new CharInfo[80 * 25];
            SmallRect rect = new SmallRect() { Left = 0, Top = 0, Right = 80, Bottom = 25 };
    
            for (byte character = 65; character < 65 + 26; ++character)
            {
              for (short attribute = 0; attribute < 15; ++attribute)
              {
                for (int i = 0; i < buf.Length; ++i)
                {
                  buf[i].Attributes = attribute;
                  buf[i].Char.AsciiChar = character;
                }
                
                bool b = WriteConsoleOutput(h, buf,
                  new Coord() { X = 80, Y = 25 },
                  new Coord() { X = 0, Y = 0 },
                  ref rect);
              }
            }
          }
          Console.ReadKey();
        }
      }
    }  
