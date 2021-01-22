    using System.Diagnostics;
    static void Main(){
        /* perform main processing */
        Process.Start("secondapp.exe", Process.GetCurrentProcess().Id.ToString());
    }
