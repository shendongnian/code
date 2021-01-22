    using System;
    using System.Runtime.InteropServices;
    namespace WinApi
    {  
        public class Mouse
        { 
                [DllImport("user32.dll")]
                private static extern void mouse_event(UInt32 dwFlags,UInt32 dx,UInt32 dy,UInt32 dwData,IntPtr dwExtraInfo);
                private const UInt32 MouseEventRightDown = 0x0008;
                private const UInt32 MouseEventRightUp = 0x0010;
 
                public static void SendRightClick(UInt32 posX, UInt32 posY)
                {
                    mouse_event(MouseEventRightDown, posX, posY, 0, new System.IntPtr());
                    mouse_event(MouseEventRightUp, posX, posY, 0, new System.IntPtr());
                }    
        }
    }
