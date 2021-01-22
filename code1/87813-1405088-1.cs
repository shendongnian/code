    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Diagnostics;
    
    namespace Util
    {
        public class ModalChecker
        {
            public static Boolean IsWaitingForUserInput(String processName)
            {
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length == 0)
                    throw new Exception("No process found matching the search criteria");
                if (processes.Length > 1)
                    throw new Exception("More than one process found matching the search criteria");
                // for thread safety
                ModalChecker checker = new ModalChecker(processes[0]);
                return checker.WaitingForUserInput;
            }
    
            #region Native Windows Stuff
            private const int WS_EX_DLGMODALFRAME = 0x00000001;
            private const int GWL_EXSTYLE = (-20);
            private delegate int EnumWindowsProc(IntPtr hWnd, int lParam);
            [DllImport("user32")]
            private extern static int EnumWindows(EnumWindowsProc lpEnumFunc, int lParam);
            [DllImport("user32", CharSet = CharSet.Auto)]
            private extern static uint GetWindowLong(IntPtr hWnd, int nIndex);
            [DllImport("user32")]
            private extern static uint GetWindowThreadProcessId(IntPtr hWnd, out IntPtr lpdwProcessId);
            #endregion
    
            // The process we want the info from
            private Process _process;
            private Boolean _waiting;
    
            private ModalChecker(Process process)
            {
                _process = process;
                _waiting = false; //default
            }
    
            private Boolean WaitingForUserInput
            {
                get
                {
                    EnumWindows(new EnumWindowsProc(this.WindowEnum), 0);
                    return _waiting;
                }
            }
    
            private int WindowEnum(IntPtr hWnd, int lParam)
            {
                IntPtr processId;
                GetWindowThreadProcessId(hWnd, out processId);
                if (processId.ToInt32() != _process.Id)
                    return 1;
                // belongs to our process, check it!
                uint style = GetWindowLong(hWnd, GWL_EXSTYLE);
                if ((style & WS_EX_DLGMODALFRAME) != 0)
                {
                    _waiting = true;
                    return 0; // stop searching further
                }
                return 1;
            }
        }
    }
