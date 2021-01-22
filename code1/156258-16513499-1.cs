    using System.Runtime.InteropServices; 
    ....
    public class anyname
    { 
    ....
    
    [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
    
    private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
    
    public static void alzheimer()
    {
    GC.Collect();
    GC.WaitForPendingFinalizers();
    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
    } 
