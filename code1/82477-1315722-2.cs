    using System;
    using System.Diagnostics;
    
    namespace Test {
        
        class TrueCrypeStart
        {
            static void Main(string[] args)
            {
                string password = getPassword(...);
                Process tc= new Process();
    
                tc.StartInfo.FileName   = "TrueCrypt.exe";
                tc.StartInfo.Arguments = string.Format("/v \"{0}\" /p \"{1}\" /q", ...mount info ..., password); // for quiet!
    
                tc.Start();
            }
        }
    }
