    using System;
    using System.Runtime.InteropServices;
    
    namespace Test
    {
        internal class Program
        {
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetStdHandle(int handle);
    
            private static void Main(string[] args)
            {
                IntPtr hConsole = GetStdHandle(-11);
                SetConsoleDisplayMode(hConsole, 1, out COORD b1);
                Console.ReadLine();
            }
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);
    
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
        }
    }
