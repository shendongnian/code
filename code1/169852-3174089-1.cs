    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    namespace ConsoleApplication1
    {
      class Program
      {
        [STAThread]
        static void Main(string[] args)
        {
          Console.SetCursorPosition(0, 0);
          for (int x = 0; x < 80 * 25; ++x)
          {
            Console.Write("A");
          }
          Console.SetCursorPosition(0, 0);
          Console.ReadKey(true);
          ClearArea(1, 1, 78, 23);
          Console.ReadKey();
        }
        static void ClearArea(short left, short top, short width, short height)
        {
          ClearArea(left, top, width, height, new CharInfo() { Char = new CharUnion() { AsciiChar = 32 } });
        }
        static void ClearArea(short left, short top, short width, short height, CharInfo charAttr)
        {
          using (SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero))
          {
            if (!h.IsInvalid)
            {
              CharInfo[] buf = new CharInfo[width * height];
              for (int i = 0; i < buf.Length; ++i)
              {
                buf[i] = charAttr;
              }
              SmallRect rect = new SmallRect() { Left = left, Top = top, Right = (short)(left + width), Bottom = (short)(top + height) };
              WriteConsoleOutput(h, buf,
                new Coord() { X = width, Y = height },
                new Coord() { X = 0, Y = 0 },
                ref rect);
            }
          }
        }
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
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
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
          [FieldOffset(0)]
          public char UnicodeChar;
          [FieldOffset(0)]
          public byte AsciiChar;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
          [FieldOffset(0)]
          public CharUnion Char;
          [FieldOffset(2)]
          public short Attributes;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect
        {
          public short Left;
          public short Top;
          public short Right;
          public short Bottom;
        }   
      }
    }
