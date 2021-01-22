    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace SingleInstanceUtilities
    {
        public sealed class SingleInstance
        {
            private const int HWND_BROADCAST = 0xFFFF;
    
            [DllImport("user32.dll")]
            private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            private static extern int RegisterWindowMessage(string message);
    
            [DllImport("user32.dll")]
            private static extern bool SetForegroundWindow(IntPtr hWnd);
    
            public SingleInstance(string uniqueName)
            {
                if (uniqueName == null)
                    throw new ArgumentNullException("uniqueName");
    
                Mutex = new Mutex(true, uniqueName);
                Message = RegisterWindowMessage("WM_" + uniqueName);
            }
    
            public Mutex Mutex { get; private set; }
            public int Message { get; private set; }
    
            public void RunFirstInstance(Action action)
            {
                RunFirstInstance(action, IntPtr.Zero, IntPtr.Zero);
            }
    
            // NOTE: if this always return false, close & restart Visual Studio
            // this is probably due to the vshost.exe thing
            public void RunFirstInstance(Action action, IntPtr wParam, IntPtr lParam)
            {
                if (action == null)
                    throw new ArgumentNullException("action");
    
                if (WaitForMutext(wParam, lParam))
                {
                    try
                    {
                        action();
                    }
                    finally
                    {
                        ReleaseMutex();
                    }
                }
            }
    
            public static void ActivateWindow(IntPtr hwnd)
            {
                if (hwnd == IntPtr.Zero)
                    return;
    
                FormUtilities.ActivateWindow(FormUtilities.GetModalWindow(hwnd));
            }
    
            public void OnWndProc(IntPtr hwnd, int m, IntPtr wParam, IntPtr lParam, bool restorePlacement, bool activate)
            {
                if (m == Message)
                {
                    if (restorePlacement)
                    {
                        WindowPlacement placement = WindowPlacement.GetPlacement(hwnd, false);
                        if (placement.IsValid && placement.IsMinimized)
                        {
                            const int SW_SHOWNORMAL = 1;
                            placement.ShowCmd = SW_SHOWNORMAL;
                            placement.SetPlacement(hwnd);
                        }
                    }
    
                    if (activate)
                    {
                        SetForegroundWindow(hwnd);
                        FormUtilities.ActivateWindow(FormUtilities.GetModalWindow(hwnd));
                    }
                }
            }
    
    #if WINFORMS // define this for Winforms apps
            public void OnWndProc(System.Windows.Forms.Form form, int m, IntPtr wParam, IntPtr lParam, bool activate)
            {
                if (form == null)
                    throw new ArgumentNullException("form");
    
                if (m == Message)
                {
                    if (activate)
                    {
                        if (form.WindowState == System.Windows.Forms.FormWindowState.Minimized)
                        {
                            form.WindowState = System.Windows.Forms.FormWindowState.Normal;
                        }
    
                        form.Activate();
                        FormUtilities.ActivateWindow(FormUtilities.GetModalWindow(form.Handle));
                    }
                }
            }
    
            public void OnWndProc(System.Windows.Forms.Form form, System.Windows.Forms.Message m, bool activate)
            {
                if (form == null)
                    throw new ArgumentNullException("form");
    
                OnWndProc(form, m.Msg, m.WParam, m.LParam, activate);
            }
    #endif
    
            public void ReleaseMutex()
            {
                Mutex.ReleaseMutex();
            }
    
            public bool WaitForMutext(bool force, IntPtr wParam, IntPtr lParam)
            {
                bool b = PrivateWaitForMutext(force);
                if (!b)
                {
                    PostMessage((IntPtr)HWND_BROADCAST, Message, wParam, lParam);
                }
                return b;
            }
    
            public bool WaitForMutext(IntPtr wParam, IntPtr lParam)
            {
                return WaitForMutext(false, wParam, lParam);
            }
    
            private bool PrivateWaitForMutext(bool force)
            {
                if (force)
                    return true;
    
                try
                {
                    return Mutex.WaitOne(TimeSpan.Zero, true);
                }
                catch (AbandonedMutexException)
                {
                    return true;
                }
            }
        }
    
        // NOTE: don't add any field or public get/set property, as this must exactly map to Windows' WINDOWPLACEMENT structure
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowPlacement
        {
            public int Length { get; set; }
            public int Flags { get; set; }
            public int ShowCmd { get; set; }
            public int MinPositionX { get; set; }
            public int MinPositionY { get; set; }
            public int MaxPositionX { get; set; }
            public int MaxPositionY { get; set; }
            public int NormalPositionLeft { get; set; }
            public int NormalPositionTop { get; set; }
            public int NormalPositionRight { get; set; }
            public int NormalPositionBottom { get; set; }
    
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool SetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);
    
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);
    
            private const int SW_SHOWMINIMIZED = 2;
    
            public bool IsMinimized
            {
                get
                {
                    return ShowCmd == SW_SHOWMINIMIZED;
                }
            }
    
            public bool IsValid
            {
                get
                {
                    return Length == Marshal.SizeOf(typeof(WindowPlacement));
                }
            }
    
            public void SetPlacement(IntPtr windowHandle)
            {
                SetWindowPlacement(windowHandle, ref this);
            }
    
            public static WindowPlacement GetPlacement(IntPtr windowHandle, bool throwOnError)
            {
                WindowPlacement placement = new WindowPlacement();
                if (windowHandle == IntPtr.Zero)
                    return placement;
    
                placement.Length = Marshal.SizeOf(typeof(WindowPlacement));
                if (!GetWindowPlacement(windowHandle, ref placement))
                {
                    if (throwOnError)
                        throw new Win32Exception(Marshal.GetLastWin32Error());
    
                    return new WindowPlacement();
                }
                return placement;
            }
        }
    
        public static class FormUtilities
        {
            [DllImport("user32.dll")]
            private static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);
    
            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr SetActiveWindow(IntPtr hWnd);
    
            [DllImport("user32.dll")]
            private static extern bool IsWindowVisible(IntPtr hWnd);
    
            [DllImport("kernel32.dll")]
            public static extern int GetCurrentThreadId();
    
            private delegate bool EnumChildrenCallback(IntPtr hwnd, IntPtr lParam);
    
            [DllImport("user32.dll")]
            private static extern bool EnumThreadWindows(int dwThreadId, EnumChildrenCallback lpEnumFunc, IntPtr lParam);
    
            private class ModalWindowUtil
            {
                private const int GW_OWNER = 4;
                private int _maxOwnershipLevel;
                private IntPtr _maxOwnershipHandle;
    
                private bool EnumChildren(IntPtr hwnd, IntPtr lParam)
                {
                    int level = 1;
                    if (IsWindowVisible(hwnd) && IsOwned(lParam, hwnd, ref level))
                    {
                        if (level > _maxOwnershipLevel)
                        {
                            _maxOwnershipHandle = hwnd;
                            _maxOwnershipLevel = level;
                        }
                    }
                    return true;
                }
    
                private static bool IsOwned(IntPtr owner, IntPtr hwnd, ref int level)
                {
                    IntPtr o = GetWindow(hwnd, GW_OWNER);
                    if (o == IntPtr.Zero)
                        return false;
    
                    if (o == owner)
                        return true;
    
                    level++;
                    return IsOwned(owner, o, ref level);
                }
    
                public static void ActivateWindow(IntPtr hwnd)
                {
                    if (hwnd != IntPtr.Zero)
                    {
                        SetActiveWindow(hwnd);
                    }
                }
    
                public static IntPtr GetModalWindow(IntPtr owner)
                {
                    ModalWindowUtil util = new ModalWindowUtil();
                    EnumThreadWindows(GetCurrentThreadId(), util.EnumChildren, owner);
                    return util._maxOwnershipHandle; // may be IntPtr.Zero
                }
            }
    
            public static void ActivateWindow(IntPtr hwnd)
            {
                ModalWindowUtil.ActivateWindow(hwnd);
            }
    
            public static IntPtr GetModalWindow(IntPtr owner)
            {
                return ModalWindowUtil.GetModalWindow(owner);
            }
        }
    }
