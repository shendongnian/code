    public class Program
    {
        static void Main(string[] args)
        {            
            ExecuteCommand(@"cmd.exe", @"/c C:\Users\*****\Documents\Test\ConsoleApp1.exe");            
        }
        public static int ExecuteCommand(string exePath, string cmdText)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();            
            startInfo.FileName = exePath;
            startInfo.Arguments = cmdText;
            startInfo.RedirectStandardError = true;            
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;            
            process.Start();            
            process.BeginErrorReadLine();
            process.WaitForExit();
            return process.ExitCode;
        }
    } 
