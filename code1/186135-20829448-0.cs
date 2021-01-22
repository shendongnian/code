    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            #region P/Invokes
    
            struct INPUT
            {
                public INPUTType type;
                public INPUTUnion Event;
            }
    
            [StructLayout(LayoutKind.Explicit)]
            struct INPUTUnion
            {
                [FieldOffset(0)]
                internal MOUSEINPUT mi;
                [FieldOffset(0)]
                internal KEYBDINPUT ki;
                [FieldOffset(0)]
                internal HARDWAREINPUT hi;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public int mouseData;
                public int dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct KEYBDINPUT
            {
                public short wVk;
                public short wScan;
                public KEYEVENTF dwFlags;
                public int time;
                public IntPtr dwExtraInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct HARDWAREINPUT
            {
                public int uMsg;
                public short wParamL;
                public short wParamH;
            }
    
            enum INPUTType : uint
            {
                INPUT_KEYBOARD = 1
            }
    
            [Flags]
            enum KEYEVENTF : uint
            {
                EXTENDEDKEY = 0x0001,
                KEYUP = 0x0002,
                SCANCODE = 0x0008,
                UNICODE = 0x0004
            }
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern UInt32 SendInput(int numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);
    
            private static void Send(string s)
            {
                foreach (var c in s)
                    Send(c);
            }
    
            private static void Send(char c)
            {
                SendKeyInternal((short)c);
            }
    
            #endregion
    
            private static void SendKeyInternal(short key)
            {
                // create input events as unicode with first down, then up
                INPUT[] inputs = new INPUT[2];
                inputs[0].type = inputs[1].type = INPUTType.INPUT_KEYBOARD;
                inputs[0].Event.ki.dwFlags = inputs[1].Event.ki.dwFlags = KEYEVENTF.UNICODE;
                inputs[0].Event.ki.wScan = inputs[1].Event.ki.wScan = key;    
                inputs[1].Event.ki.dwFlags |= KEYEVENTF.KEYUP;
    
                uint cSuccess = SendInput(inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
                if (cSuccess != inputs.Length)
                {
                    throw new Win32Exception();
                }
            }
    
            static void Main(string[] args)
            {
                System.Threading.Thread.Sleep(3000);
                Send("Hello world!");
            }
        }
    }
