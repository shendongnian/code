    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    public class Test 
    {
    
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        
        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);
        
        public static void Main()
        {
            string originalTitle = Console.Title;
            string uniqueTitle = Guid.NewGuid().ToString();
            Console.Title = uniqueTitle;
            Thread.Sleep(50);
            IntPtr handle = FindWindowByCaption(IntPtr.Zero, uniqueTitle);
            
            if (handle == IntPtr.Zero)
            {
                Console.WriteLine("Oops, cant find main window.");
                return;
            }
            Console.Title = originalTitle;
            
            while (true)
            {
                Thread.Sleep(3000);
                Console.WriteLine(SetForegroundWindow(handle));
            }
        }
    }
