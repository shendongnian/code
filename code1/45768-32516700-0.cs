    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    
    namespace monitor_on_off
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll")]
            static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);
    
            private const int WM_SYSCOMMAND = 0x0112;
            private const int SC_MONITORPOWER = 0xF170;
            private const int MonitorShutoff = 2;
            private const int MOUSEEVENTF_MOVE = 0x0001;
    
            public static void MonitorOff(IntPtr handle)
            {
                SendMessage(handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MonitorShutoff);
            }
    
            private static void MonitorOn(IntPtr handle)
            {
                mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero);
                Thread.Sleep(40);
                mouse_event(MOUSEEVENTF_MOVE, 0, -1, 0, UIntPtr.Zero);
            }
    
            static void Main(string[] args)
            {
                var form = new Form();
    
                while (true)
                {
                    MonitorOff(form.Handle);
                    Thread.Sleep(5000);
                    MonitorOn(form.Handle);
                    Thread.Sleep(5000);
                }
            }
        }
    }
