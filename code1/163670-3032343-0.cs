    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace swflauncher
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process flash = new Process();
                flash.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                
                flash.StartInfo.FileName = "D:\\development\\flex4\\runtimes\\player\\10\\win\\FlashPlayer.exe";
                flash.Start();
                Thread.Sleep(100);
    
                IntPtr id = flash.MainWindowHandle;
                Console.Write(id);
                Program.MoveWindow(flash.MainWindowHandle, 0, 0, 500, 500, true);
            }
         
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    
           
        }
    }
