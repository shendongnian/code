    public class YourEnumerateClass
    {
        public static void Enum16BitProcesses()
        {
            // create a delegate for the callback function
            ProcessTasksExDelegate procTasksDlgt = 
                 new ProcessTasksExDelegate(YourEnumerateClass.ProcessTasksEx);
            // this part is the easy way of getting NTVDM procs
            foreach (var ntvdm in Process.GetProcessesByName("ntvdm"))
            {
                Console.WriteLine("ntvdm id = {0}", ntvdm.Id);
                int apiRet = VDMEnumTaskWOWEx(ntvdm.Id, procTasksDlgt, IntPtr.Zero);
                Console.WriteLine("EnumTaskWOW returns {0}", apiRet);
            }
        
        }
        
        // declaration of API function callback
        public delegate bool ProcessTasksExDelegate(
            int ThreadId,
            IntPtr hMod16,
            IntPtr hTask16,
            IntPtr ptrModName,
            IntPtr ptrFileName,
            IntPtr UserDefined
            );
        
        // the actual function that fails on Vista so far
        [DllImport("VdmDbg.dll", SetLastError = false, CharSet = CharSet.Auto)]
        public static extern int VDMEnumTaskWOWEx(
            int processId, 
            ProcessTasksExDelegate TaskEnumProc, 
            IntPtr lparam);
        
        // the actual callback function, on Vista never gets called
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
    
    }
