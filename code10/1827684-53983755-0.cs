    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace findwindow
    {
    	class Program
    	{
    		[DllImport("user32.dll", SetLastError = true)]
    		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    		static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    		public static void Main(string[] args)
    		{
    			Process.Start(new ProcessStartInfo(){FileName=@"C:\Windows\System32\SystemPropertiesPerformance.exe"});
    			System.Threading.Thread.Sleep(100);
    			IntPtr hwnd = FindWindow("#32770", "Параметры быстродействия");
    			var sb = new StringBuilder(50);
    			GetWindowText(hwnd, sb, 49);
    			Console.WriteLine("hwnd:"+hwnd+", title:"+sb);
                Console.ReadKey(true);
    		}
    	}
    }
