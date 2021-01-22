    private void Enum16BitProcesses()
    {
        List<Process> ntvdms = new List<Process>();
        ProcessTasksExDelegate procTasksDlgt = new ProcessTasksExDelegate(Form2.ProcessTasksEx);
        foreach (var ntvdm in Process.GetProcessesByName("ntvdm"))
        {
            Console.WriteLine("ntvdm id = {0}", ntvdm.Id);
            int apiRet = VDMEnumTaskWOWEx(ntvdm.Id, procTasksDlgt, IntPtr.Zero);
            Console.WriteLine("EnumTaskWOW returns {0}", apiRet);
        }
    
    }
    
    public delegate bool ProcessTasksExDelegate(
        int ThreadId,
        IntPtr hMod16,
        IntPtr hTask16,
        IntPtr ptrModName,
        IntPtr ptrFileName,
        IntPtr UserDefined
        );
    
    [DllImport("VdmDbg.dll", SetLastError = false, CharSet = CharSet.Auto)]
    public static extern int VDMEnumTaskWOWEx(
        int processId, 
        ProcessTasksExDelegate TaskEnumProc, 
        IntPtr lparam);
    
    public static bool ProcessTasksEx(
        int ThreadId,
        IntPtr hMod16,
        IntPtr hTask16,
        IntPtr ptrModName,
        IntPtr ptrFileName,
        IntPtr UserDefined
        )
    {
        string filename = Marshal.PtrToStringAuto(ptrFileName);
        Console.WriteLine("Filename of WOW16 process: {0}", filename);
        return false;       // false continues enumeration
    }
