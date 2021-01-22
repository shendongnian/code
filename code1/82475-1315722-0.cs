    using System;
    using System.Diagnostics;
    
    namespace Test {
        
        class TrueCrypeStart
        {
            static void Main(string[] args)
            {
                Process tc= new Process();
    
                tc.StartInfo.FileName   = "TrueCrypt.exe";
                tc.StartInfo.Arguments = "/q"; // for quiet!
    
                tc.Start();
            }
        }
    }
