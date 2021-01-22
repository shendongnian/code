        using Microsoft.Win32;
    using System.Runtime.InteropServices;
    using System;
    
    using System.Windows.Forms;
    
    
    
    public class Kiosk : IDisposable
    {
    
        #region "IDisposable"
    
        // Implementing IDisposable since it might be possible for
        // someone to forget to cause the unhook to occur. I didn't really
        // see any problems with this in testing, but since the SDK says
        // you should do it, then here's a way to make sure it will happen.
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            // Free other state (managed objects).
            if (m_hookHandle != 0)
            {
                UnhookWindowsHookEx(m_hookHandle);
                m_hookHandle = 0;
            }
            if (m_taskManagerValue > -1)
            {
                EnableTaskManager();
            }
        }
    
    
    
        #endregion
    
        public static void main()
        {
    
        }
        private delegate int LowLevelHookDelegate(int code, int wParam, ref KeyboardLowLevelHookStruct lParam);
    
        private const int Hc_Action = 0;
        private const int WindowsHookKeyboardLowLevel = 13;
        private const int LowLevelKeyboardHfAltDown = 0x20;
    
        private enum WindowsMessage
        {
            KeyDown = 0x100,
            KeyUp = 0x101,
            SystemKeyDown = 0x104,
            SystemKeyUp = 0x105
        }
    
        private enum Vk
        {
            Tab = 0x9,
            Escape = 0x1b,
            Shift = 0x10,
            Control = 0x11,
            Menu = 0x12,
            // ALT key.
            Alt = 0x12,
            Pause = 0x13,
            LeftWindows = 0x5b,
            // Left Windows key (Microsoft® Natural® keyboard).
            RightWindows = 0x5c,
            // Right Windows key (Natural keyboard).
            Applications = 0x5d
            // Applications key (Natural keyboard).
        }
    
        private struct KeyboardLowLevelHookStruct
        {
            public int VirtualKeyCode;
            public int ScanCode;
            public int Flags;
            public int Time;
            public UInt32 ExtraInfo;
        }
        [DllImport("user32", EntryPoint = "SetWindowsHookExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SetWindowsHookEx(int hook, LowLevelHookDelegate address, int mod, int threadId);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int CallNextHookEx(int handle, int code, int wParam, KeyboardLowLevelHookStruct lParam);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int UnhookWindowsHookEx(int handle);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int GetAsyncKeyState(int virtualKey);
    
    
        private int m_hookHandle;
    
        private int LowLevelHook(int code, int wParam, ref KeyboardLowLevelHookStruct lParam)
        {
    
            if (code == Hc_Action)
            {
    
                if ((wParam == (int)WindowsMessage.KeyDown) || (wParam == (int)WindowsMessage.SystemKeyDown) || (wParam == (int)WindowsMessage.KeyUp) || (wParam == (int)WindowsMessage.SystemKeyUp))
                {
    
                    //Dim alt As Boolean = (GetAsyncKeyState(Vk.Alt) And &H8000) = &H8000
                    //Dim shift As Boolean = (GetAsyncKeyState(Vk.Shift) And &H8000) = &H8000
                    bool control = (GetAsyncKeyState((int)Vk.Control) & 0x8000) == 0x8000;
    
                    bool suppress = false;
    
                    // CTRL+ESC
                    if (control && lParam.VirtualKeyCode == (int)Vk.Escape)
                    {
                        suppress = true;
                    }
    
                    // ALT+TAB
                    if ((lParam.Flags & LowLevelKeyboardHfAltDown) == LowLevelKeyboardHfAltDown && lParam.VirtualKeyCode == (int)Vk.Tab)
                    {
                        suppress = true;
                    }
    
                    // ALT+ESC
                    if ((lParam.Flags & LowLevelKeyboardHfAltDown) == LowLevelKeyboardHfAltDown && lParam.VirtualKeyCode == (int)Vk.Escape)
                    {
                        suppress = true;
                    }
    
                    // Left Windows button.
                    if (lParam.VirtualKeyCode == (int)Vk.LeftWindows)
                    {
                        suppress = true;
                        MessageBox.Show("Pressed Left windows key");
                    }
    
                    // Right Windows button.
                    if (lParam.VirtualKeyCode == (int)Vk.RightWindows)
                    {
                        suppress = true;
                        
                       
                        MessageBox.Show("Pressed Right windows key");
                    }
    
                    // Applications button.
                    if (lParam.VirtualKeyCode == (int)Vk.Applications)
                    {
                        suppress = true;
                    }
    
                    if (suppress)
                    {
                        return 1;
    
                    }
                }
    
    
                return CallNextHookEx(m_hookHandle, code, wParam, lParam);
        
            }
            else
                return 1;
        }
    
        public void Disable()
        {
            if (m_hookHandle == 0)
            {
    
                m_hookHandle = SetWindowsHookEx(WindowsHookKeyboardLowLevel, LowLevelHook, Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly).ToInt32, 0);
            }
        }
    
        public void Enable()
        {
            if (m_hookHandle != 0)
            {
                UnhookWindowsHookEx(m_hookHandle);
                m_hookHandle = 0;
            }
        }
    
    }
