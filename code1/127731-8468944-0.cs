    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace Simulate
    {
        public class Simulate
        {
            [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
            static extern UInt32 SendInput(UInt32 numberOfInputs, INPUT[] input, Int32 sizeOfInputStructure);
            [StructLayout(LayoutKind.Sequential, Size = 24)]
            struct KEYBDINPUT
            {
                public UInt16 Vk;
                public UInt16 Scan;
                public UInt32 Flags;
                public UInt32 Time;
                public UInt32 ExtraInfo;
            }
            [StructLayout(LayoutKind.Explicit)]
            private struct INPUT
            {
                [FieldOffset(0)]
                public int Type;
                [FieldOffset(4)]
                public KEYBDINPUT ki;
            } 
            public static void TextInput(string text)
            {
                char[] chars = text.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    UInt16 unicode = chars[i];
                    INPUT down = new INPUT();
                    down.Type = 1; //INPUT_KEYBOARD
                    down.ki.Vk = 0;
                    down.ki.Scan = unicode;
                    down.ki.Time = 0;
                    down.ki.Flags = 0x0004; //KEYEVENTF_UNICODE
                    down.ki.ExtraInfo = 0;
                    INPUT up = new INPUT();
                    up.Type = 1; //INPUT_KEYBOARD
                    up.ki.Vk = 0;
                    up.ki.Scan = unicode;
                    up.ki.Time = 0;
                    up.ki.Flags = 0x0004; //KEYEVENTF_UNICODE
                    up.ki.ExtraInfo = 0;
                    INPUT[] input = new INPUT[2];
                    input[0] = down;
                    input[1] = up;
                    SendInput(1, input, Marshal.SizeOf(typeof(INPUT)));
                }
            }
        }
    }
    // Call the API :
    Simulate.TextInput("AbCçDeFgĞhİiJkLmNoÖpQrSşTuÜvXyZ - äÄß_0123456789");
