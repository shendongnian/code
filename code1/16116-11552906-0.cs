    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Interop;
    using System.Runtime.InteropServices;
    namespace System.Windows
    {
        public static class SystemWindows
        {
            #region Constants
            const UInt32 SWP_NOSIZE = 0x0001;
            const UInt32 SWP_NOMOVE = 0x0002;
            const UInt32 SWP_SHOWWINDOW = 0x0040;
            #endregion
            /// <summary>
            /// Activate a window from anywhere by attaching to the foreground window
            /// </summary>
            public static void GlobalActivate(this Window w)
            {
                //Get the process ID for this window's thread
                var interopHelper = new WindowInteropHelper(w);
                var thisWindowThreadId = GetWindowThreadProcessId(interopHelper.Handle, IntPtr.Zero);
                //Get the process ID for the foreground window's thread
                var currentForegroundWindow = GetForegroundWindow();
                var currentForegroundWindowThreadId = GetWindowThreadProcessId(currentForegroundWindow, IntPtr.Zero);
                //Attach this window's thread to the current window's thread
                AttachThreadInput(currentForegroundWindowThreadId, thisWindowThreadId, true);
                //Set the window position
                SetWindowPos(interopHelper.Handle, new IntPtr(0), 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_SHOWWINDOW);
                //Detach this window's thread from the current window's thread
                AttachThreadInput(currentForegroundWindowThreadId, thisWindowThreadId, false);
                //Show and activate the window
                if (w.WindowState == WindowState.Minimized) w.WindowState = WindowState.Normal;
                w.Show();
                w.Activate();
            }
            #region Imports
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
            [DllImport("user32.dll")]
            private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
            #endregion
        }
    }
