    using System;
    using System.Diagnostics;
    
    namespace SO_Question_52599105
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process process = new Process();
                process.StartInfo.FileName="bin/wrapper.sh";
                process.Start();
            }
        }
    }
