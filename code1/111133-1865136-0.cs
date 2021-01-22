        [ComVisible(true)]
        [Guid("CC5B405F-F3CD-417E-AA00-4638A12A2E94"),
        ClassInterface(ClassInterfaceType.None)]
        public class TestInterface : ITestInterface // see declaration of the interface below
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);
    
            public const int SB_SETTEXT = 1035;
            public const int SB_SETPARTS = 1028;
            public const int SB_GETPARTS = 1030;
    
            public unsafe void Test()
            {
                IntPtr mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
                // find status bar control on the main window of the application
                IntPtr statusBarHandle = FindWindowEx(mainWindowHandle, IntPtr.Zero, "msctls_statusbar32", IntPtr.Zero);
                if (statusBarHandle != IntPtr.Zero)
                {
                    // set text for the existing part with index 0
                    IntPtr text = Marshal.StringToHGlobalAuto("test text 0");
                    SendMessage(statusBarHandle, SB_SETTEXT, 0, text);
                    Marshal.FreeHGlobal(text);
                    
                    // create new parts width array
                    int nParts = SendMessage(statusBarHandle, SB_GETPARTS, 0, IntPtr.Zero).ToInt32();
                    nParts++;
                    IntPtr memPtr = Marshal.AllocHGlobal(sizeof(int) * nParts);
                    int partWidth = 100; // set parts width according to the form size
                    for (int i = 0; i < nParts; i++)
                    {
                        Marshal.WriteInt32(memPtr, i*sizeof(int), partWidth);
                        partWidth += partWidth;
                    }
                    SendMessage(statusBarHandle, SB_SETPARTS, nParts, memPtr);
                    Marshal.FreeHGlobal(memPtr);
    
                    // set text for the new part
                    IntPtr text0 = Marshal.StringToHGlobalAuto("new section text 1");
                    SendMessage(statusBarHandle, SB_SETTEXT, nParts-1, text0);
                    Marshal.FreeHGlobal(text0);
                }
            }
        }
        [ComVisible(true)]
        [Guid("694C1820-04B6-4988-928F-FD858B95C880")]
        public interface ITestInterface
        {
           [DispId(1)]
           void Test();
        }
