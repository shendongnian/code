    using System;
    using System.Runtime.InteropServices;
    
    namespace Test
    {
        internal class Program
        {
            [DllImport("kernel32.dll")]
            private static extern bool GetConsoleScreenBufferInfo(IntPtr hConsole, out CONSOLE_SCREEN_BUFFER_INFO info);
    
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetStdHandle(int handle);
    
            private static void Main(string[] args)
            {
                Console.WriteLine("Press Enter to cycle through the options");
                Console.ReadLine();
                IntPtr hConsole = GetStdHandle(-11);
                CONSOLE_SCREEN_BUFFER_INFO info;
                GetConsoleScreenBufferInfo(hConsole, out info);
                SMALL_RECT rc;
                rc.Left = rc.Top = 0;
                rc.Right = (short)(Math.Min(info.MaximumWindowSize.X, info.Size.X) - 1);
                rc.Bottom = (short)(Math.Min(info.MaximumWindowSize.Y, info.Size.Y) - 1);
                SetConsoleWindowInfo(hConsole, true, ref rc);
                Console.ReadLine();
                SetConsoleDisplayMode(hConsole, 1, out COORD b1);
                Console.ReadLine();
                SetConsoleDisplayMode(hConsole, 2, out COORD b2);
                Console.WriteLine("Goodbye");
                Console.ReadLine();
            }
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetConsoleWindowInfo(IntPtr hConsole, bool absolute, ref SMALL_RECT rect);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct COORD
            {
                public short X;
                public short Y;
    
                public COORD(short X, short Y)
                {
                    this.X = X;
                    this.Y = Y;
                }
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct CONSOLE_SCREEN_BUFFER_INFO
            {
                public COORD Size;
                public COORD CursorPosition;
                public short Attributes;
                public SMALL_RECT Window;
                public COORD MaximumWindowSize;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct SMALL_RECT
            {
                public short Left;
                public short Top;
                public short Right;
                public short Bottom;
            }
        }
    }
