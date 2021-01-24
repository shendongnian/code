    public class UnmanagedCode
    {
        [DllImport("user32")]
        public static extern int EnumWindows(EnumWindowsDelegate CallBack, 
          ProcessWatcher processWatcher);
        [DllImport("user32")]
        internal static extern bool IsWindowVisible(int hWnd);
        [DllImport("User32.Dll")]
        public static extern void GetWindowText(int hWnd, StringBuilder sb, int maxCount);
        [DllImport("User32.Dll")]
        public static extern void GetClassName(int hWnd, StringBuilder sb, int maxCount);
        public static bool EnumWindowsCallBack(int Hwnd, ProcessWatcher processWatcher)
        {
            if (!IsWindowVisible(Hwnd))
                return true;
            if (IsAltTabWindow(Hwnd))
            {
                try
                {
                    StringBuilder windowClass = new StringBuilder(256);
                    UnmanagedCode.GetClassName(Hwnd, windowClass, windowClass.Capacity);
                    StringBuilder windowText = new StringBuilder(256);
                    UnmanagedCode.GetWindowText(Hwnd, windowText, windowText.Capacity);
                    IntPtr pid = (IntPtr)0;
                    GetWindowThreadProcessId(Hwnd, ref pid);
                    processWatcher.Add(pid.ToInt32(), 
                      Hwnd, 
                      windowClass.ToString(), 
                      windowText.ToString());
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            return true;
        }
        internal static bool IsAltTabWindow(int hwnd)
        {
            // Start at the root owner
            int hwndWalk = GetAncestor(hwnd, 3);
            // See if we are the last active visible popup
            int hwndTry;
            while ((hwndTry = GetLastActivePopup(hwndWalk)) != hwndTry)
            {
                if (IsWindowVisible(hwndTry)) break;
                hwndWalk = hwndTry;
            }
            return hwndWalk == hwnd;
        }
    }
    public class ProcessWatcher
    {
      private List<MyProcess> _processes = new List<MyProcess>;
      public UnmanagedCode.EnumWindowsDelegate callback 
        = new UnmanagedCode.EnumWindowsDelegate(UnmanagedCode.EnumWindowsCallBack);
      public void Update()
      {
        foreach (var proc in _processes )
        {
          proc.Updated = false;
        }
        UnmanagedCode.EnumWindows(callback, this);
        _processes = _processes
          .Where(p => p.Updated)
          .ToList();
      }
      public void Add(int processID, 
        int windowHandle, 
        string className, 
        string windowText)
      {
        var currentProcess = _processes.FirstOdDefault(p => p.ProcessId = processId);
        if (currentProcess != null)
        {
          // still running, already found
          currentProcess.Updated = true;
        }
        else // new process
        {
          try
          {
            Process proc = Process.GetProcessById(processId)
            fileName = proc.MainModule.ModuleName;
            _processes.Add(new MyProcess
              {
                ProcessId = processId,
                WindowHandle = windowHandle,
                ClassName = className,
                WindowText = windowText,
                FileName = fileName
              });
          }
          catch {}
        }
    }
