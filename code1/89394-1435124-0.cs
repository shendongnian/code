    public class ParentProc { 
    
    [DllImport("KERNEL32.dll")] //[DllImport("toolhelp.dll")] 
    public static extern int CreateToolhelp32Snapshot(uint flags, uint processid); 
    
    [DllImport("KERNEL32.DLL")] //[DllImport("toolhelp.dll")] 
    public static extern int CloseHandle(int handle); 
    
    [DllImport("KERNEL32.DLL")] //[DllImport("toolhelp.dll") 
    public static extern int Process32Next(int handle, ref ProcessEntry32 pe); 
    
    [StructLayout(LayoutKind.Sequential)] 
    public struct ProcessEntry32 { 
    public uint dwSize; 
    public uint cntUsage; 
    public uint th32ProcessID; 
    public IntPtr th32DefaultHeapID; 
    public uint th32ModuleID; 
    public uint cntThreads; 
    public uint th32ParentProcessID; 
    public int pcPriClassBase; 
    public uint dwFlags; 
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)] public string szExeFile; 
    }; 
    
    public static Process FindParentProcess() { 
    
    int SnapShot = CreateToolhelp32Snapshot(0x00000002, 0); //2 = SNAPSHOT of all procs 
    try{ 
    ProcessEntry32 pe32 = new ProcessEntry32(); 
    pe32.dwSize = 296; 
    int procid = System.Diagnostics.Process.GetCurrentProcess().Id; 
    while(Process32Next(SnapShot, ref pe32) != 0) { 
    string xname = pe32.szExeFile.ToString(); 
    if(procid==pe32.th32ProcessID) { 
    return System.Diagnostics.Process.GetProcessById(Convert.ToInt32(pe32.th32ParentProcessID)); 
    } 
    } 
    
    }catch(Exception ex){ 
    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod() + " failed! [Type:"+ex.GetType().ToString()+", Msg:"+ex.Message+"]"); 
    }finally{ 
    CloseHandle(SnapShot); 
    } 
    return null; 
    } 
    
    }
