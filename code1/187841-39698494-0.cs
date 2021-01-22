    public static class LowLevelConsole {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern SafeFileHandle CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] uint fileAccess,
            [MarshalAs(UnmanagedType.U4)] uint fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] int flags,
            IntPtr template);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);
        [StructLayout(LayoutKind.Sequential)]
        public struct Coord {
            public short X;
            public short Y;
            public Coord(short X, short Y) {
                this.X = X;
                this.Y = Y;
            }
        };
        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion {
            [FieldOffset(0)]
            public char UnicodeChar;
            [FieldOffset(0)]
            public byte AsciiChar;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo {
            [FieldOffset(0)]
            public CharUnion Char;
            [FieldOffset(2)]
            public ushort Attributes;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SmallRect {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }
        [STAThread]
        public static void Write(string line, CharacterAttribute attribute, short xLoc, short yLoc) {
            SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            short writeHeight = 1;
            short writeWidth = (short)line.Length;
            if (!h.IsInvalid) {
                CharInfo[] buf = new CharInfo[writeWidth * writeHeight];
                SmallRect rect = new SmallRect() { Left = xLoc, Top = yLoc, Right = (short)(writeWidth + xLoc), Bottom = (short)(writeHeight + yLoc) };
                for (int i = 0; i < writeWidth; i++) {
                    buf[i].Attributes = (ushort)attribute;
                    buf[i].Char.UnicodeChar = line[i];
                }
                bool b = WriteConsoleOutput(h, buf, new Coord() { X = writeWidth, Y = writeHeight }, new Coord() { X = 0, Y = 0 }, ref rect);
            }
        }
        [STAThread]
        public static bool WriteBuffer(CharInfo[,] buffer) { // returns true of success
            SafeFileHandle h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            if (!h.IsInvalid) {
                short BufferWidth = (short)buffer.GetLength(0);
                short BufferHeight = (short)buffer.GetLength(1);
                CharInfo[] buf = new CharInfo[BufferWidth * BufferHeight];
                SmallRect rect = new SmallRect() { Left = 0, Top = 0, Right = BufferWidth, Bottom = BufferHeight };
                for (int y = 0; y < BufferHeight; y++) {
                    for (int x = 0; x < BufferWidth; x++) {
                        buf[y * BufferWidth + x] = buffer[x, y];
                    }
                }
                return WriteConsoleOutput(h, buf, new Coord() { X = BufferWidth, Y = BufferHeight }, new Coord() { X = 0, Y = 0 }, ref rect);
            }
            return false;
        }
    }
