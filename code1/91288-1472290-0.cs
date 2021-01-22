    using System;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            Process netTime = new Process();
            netTime.StartInfo.FileName   = "NET.exe";
            netTime.StartInfo.Arguments = "TIME /domain:mydomainname /SET /Y";
            netTime.Start();
        }
    }
     
