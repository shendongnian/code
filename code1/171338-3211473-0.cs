    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Text;
    
    public class MainClass
    
        // Declare external functions.
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
    
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
    
        public static void Main() {
            int chars = 256;
            StringBuilder buff = new StringBuilder(chars);
    
            // Obtain the handle of the active window.
            IntPtr handle = GetForegroundWindow();
    
            // Update the controls.
            if (GetWindowText(handle, buff, chars) > 0)
            {
                Console.WriteLine(buff.ToString());
                Console.WriteLine(handle.ToString());
            }
        }
    }
