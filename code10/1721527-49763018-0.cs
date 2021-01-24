    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace ConsoleApp1
    {
        class Program
        {
            [DllImport("user32.dll")] static extern short VkKeyScan(char c);
    
            static void Main(string[] args)
            {
                var s = "~|-.";
                foreach(var c in s)
                {
                    var key = VirtualKeyCodeFromChar(c);
                    Console.WriteLine($"{c}, {key}, 0x{key:X}\n");
                }
    
                Console.ReadKey();
            }
    
            static int VirtualKeyCodeFromChar(char c)
            {
                var composite = VkKeyScan(c);
    
                byte keyCode = (byte)(composite & 255);
                byte shiftState = (byte)((composite >> 8) & 255);
    
                Keys key = (Keys)keyCode;
    
                if ((shiftState & 1) != 0) key |= Keys.Shift;
                if ((shiftState & 2) != 0) key |= Keys.Control;
                if ((shiftState & 4) != 0) key |= Keys.Alt;
    
                return (int)key;
            }
        }
    }
