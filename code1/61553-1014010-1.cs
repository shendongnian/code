    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    namespace TestApp
    {
    public static class Messenger
    {
        public const uint WM_USER = 0x0400;
        public const int MyMessage = 0x00000001;;
        [DllImport("User32.dll")]
        private static extern int RegisterWindowMessage(string lpString);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        internal static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        internal static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        internal static extern int PostMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        internal static extern uint SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        internal static extern int PostMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        internal static extern bool SetForegroundWindow(int hWnd);
        //Used for WM_COPYDATA for string messages
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        internal static int sendWindowsStringMessage(int hWnd, int wParam, string msg)
        {
            int result = 0;
            if (hWnd > 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = msg;
                cds.cbData = len + 1;
                result = SendMessage(hWnd, (int)WM_USER, wParam, ref cds);
            }
            return result;
        }
        internal static uint sendWindowsMessage(IntPtr hWnd, uint Msg, IntPtr wParam, int lParam)
        {
            uint result = 0;
            if (hWnd != IntPtr.Zero)
            {
                result = SendMessage(hWnd, Msg, wParam, lParam);
            }
            return result;
        }
        internal static IntPtr getWindowId(string className, string windowName)
        {
            return FindWindow(className, windowName);
        }
    }
