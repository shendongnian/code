    using System.Diagnostics;
    static void Main(string[] args){
        Process.GetProcessById(int.Parse(args[0]))
             .WaitForExit();
        /* perform main processing */
    }
