    using System;
    using System.Diagnostics;
    
    public class RedirectingProcessOutput
    {
        public static void Main()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c dir *.cs";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            
            string output = p.StandardOutput.ReadToEnd();
            
            Console.WriteLine("Output:");
            Console.WriteLine(output);    
        }
    }
