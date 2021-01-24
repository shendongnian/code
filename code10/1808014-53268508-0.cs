    using HookInput.API;
    using HookInput.Mouse;
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace ConsoleApp3
    {
        public class Program
        {
            private static MouseInput mouseInputHook = null;
    
            static void Main(string[] args)
            {
                var vc = new  VolumeControl();
                mouseInputHook = new MouseInput(vc);
                mouseInputHook.setHook(true);
                Console.WriteLine("hook activated");
                Application.Run(new ApplicationContext());
            }
        }
    
        public class VolumeControl
        {
            private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
            private const int APPCOMMAND_VOLUME_UP = 0xA0000;
            private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
            private const int WM_APPCOMMAND = 0x319;
    
            public IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
    
            public void VolDown()
            {
                WindowsHookAPI.SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
            }
    
            public void VolUp()
            {
                WindowsHookAPI.SendMessageW(handle, WM_APPCOMMAND, handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }
    }
