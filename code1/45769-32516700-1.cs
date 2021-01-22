    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    
    
    namespace monitor_on_off
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll")]
            static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);
    
            private const int WmSyscommand = 0x0112;
            private const int ScMonitorpower = 0xF170;
            private const int MonitorShutoff = 2;
            private const int MouseeventfMove = 0x0001;
    
            public static void MonitorOff(IntPtr handle)
            {
                SendMessage(handle, WmSyscommand, (IntPtr)ScMonitorpower, (IntPtr)MonitorShutoff);
            }
    
            private static void MonitorOn()
            {
                mouse_event(MouseeventfMove, 0, 1, 0, UIntPtr.Zero);
                Thread.Sleep(40);
                mouse_event(MouseeventfMove, 0, -1, 0, UIntPtr.Zero);
            }
    
            static void Main()
            {
                var form = new Form();
    
                while (true)
                {
                    MonitorOff(form.Handle);
                    Thread.Sleep(5000);
                    MonitorOn();
                    Thread.Sleep(5000);
                }
            }
        }
    }
