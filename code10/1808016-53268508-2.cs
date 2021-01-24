    using HookInput.API;
    using System;
    using System.IO.MemoryMappedFiles;
    using System.Runtime.InteropServices;
    using ConsoleApp3;
    
    namespace HookInput.Mouse
    {
        public class MouseInput
        {
            private const Int32 WM_MOUSEMOVE = 0x0200;
    
            private const Int32 WM_LBUTTONDOWN = 0x0201;
            private const Int32 WM_LBUTTONUP = 0x0202;
            private const Int32 WM_LBUTTONDBLCLK = 0x0203;
            private const Int32 WM_RBUTTONDOWN = 0x0204;
            private const Int32 WM_RBUTTONUP = 0x0205;
            private const Int32 WM_RBUTTONDBLCLK = 0x0206;
            private const Int32 WM_MBUTTONDOWN = 0x0207;
            private const Int32 WM_MBUTTONUP = 0x0208;
            private const Int32 WM_MBUTTONDBLCLK = 0x0209;
    
            private const Int32 WM_MOUSEWHEEL = 0x020A;
    
            private const Int32 WM_XBUTTONDOWN = 0x020B;
            private const Int32 WM_XBUTTONUP = 0x020C;
            private const Int32 WM_XBUTTONDBLCLK = 0x020D;
    
            private MemoryMappedViewAccessor accessor;
    
            private bool hooked = false;
    
            private WindowsHookAPI.HookDelegate mouseDelegate;
            private IntPtr mouseHandle;
    
    
            private const Int32 WH_MOUSE_LL = 14;
    
            private readonly VolumeControl vc;
            public MouseInput(VolumeControl vc)
            {
                this.vc = vc;
            }
    
            public void setHook(bool on)
            {
                if (hooked == on) return;
                if (on)
                {
                    mouseDelegate = MouseHookDelegate;
                    mouseHandle = WindowsHookAPI.SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, IntPtr.Zero, 0);
                    if (mouseHandle != IntPtr.Zero) hooked = true;
                }
                else
                {
                    WindowsHookAPI.UnhookWindowsHookEx(mouseHandle);
                    hooked = false;
                }
            }
    
            private IntPtr MouseHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
            {
                //mouseData:
                //If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta.The low-order word is reserved.
                //    A positive value indicates that the wheel was rotated forward, away from the user;
                //    a negative value indicates that the wheel was rotated backward, toward the user. 
                //    One wheel click is defined as WHEEL_DELTA, which is 120.(0x78 or 0xFF88)
                //If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK, 
                //    the high - order word specifies which X button was pressed or released, 
                //    and the low - order word is reserved.This value can be one or more of the following values.Otherwise, mouseData is not used.
                //XBUTTON1  = 0x0001 The first X button was pressed or released.
                //XBUTTON2  = 0x0002  The second X button was pressed or released.
    
                MSLLHOOKSTRUCT lparam = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                int command = (int)wParam;
                if (Code < 0 || command == WM_LBUTTONDBLCLK || command == WM_RBUTTONDBLCLK)
                    return WindowsHookAPI.CallNextHookEx(mouseHandle, Code, wParam, lParam);
    
                else if (command == WM_XBUTTONDOWN || command == WM_XBUTTONUP)
                {
                    int numbutton = ((int)lparam.mouseData >> 16) - 1;
                    //return (IntPtr)1;
                }
                else if (command == WM_LBUTTONDOWN || command == WM_LBUTTONUP)
                {
                    if (command == WM_LBUTTONUP)
                    {
                        vc.VolDown();
                        Console.WriteLine("L down");
                    }
                }
                else if (command == WM_RBUTTONDOWN || command == WM_RBUTTONUP)
                {
                    if (command == WM_RBUTTONUP)
                    {
                        vc.VolUp();
                        Console.WriteLine("L Up");
                    }
                }
                else if (command == WM_MBUTTONDOWN || command == WM_MBUTTONUP)
                {
                    if (hooked)
                    {
                        setHook(false);
                        Console.WriteLine("hook deactivated");
                    }
                    else
                    {
                        setHook(true);
                        Console.WriteLine("hook activated");
                    }
                }
                else if (command == WM_MOUSEWHEEL)
                {
    
                }
    
                return WindowsHookAPI.CallNextHookEx(mouseHandle, Code, wParam, lParam);
            }
    
    
            ~MouseInput()
            {
    
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
        }
    }
