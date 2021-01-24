    using System;
    using System.Diagnostics;
    using System.IO;
    namespace ScriptInterface
    {
        public class ScriptRunner
        {
            //args separated by spaces
            public static string RunFromCmd(string rCodeFilePath, string args)
            {
                string file = rCodeFilePath;
                string result = string.Empty;
    
                try
                {
    
                    var info = new ProcessStartInfo(@"C:\Users\xyz\AppData\Local\Programs\Python\Python37\python.exe");
                    info.Arguments = rCodeFilePath + " " + args;
    
                    info.RedirectStandardInput = false;
                    info.RedirectStandardOutput = true;
                    info.UseShellExecute = false;
                    info.CreateNoWindow = true;
    
                    using (var proc = new Process())
                    {
                        proc.StartInfo = info;
                        proc.Start();
                        proc.WaitForExit();
                        if (proc.ExitCode == 0)
                        {
                            result = proc.StandardOutput.ReadToEnd();
                        }                    
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("R Script failed: " + result, ex);
                }
            }
            public static void Main()
            {
                string args = "1 2";
                string res = ScriptRunner.RunFromCmd(@"your file path", args);
           
            }
        }
    
    }
