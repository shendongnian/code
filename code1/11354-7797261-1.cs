    using System;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd";
         
            proc.StartInfo.Arguments = @"/C ""netsh wlan show networks mode=bssid | findstr BSSID """;
    
            proc.StartInfo.RedirectStandardOutput = true;       
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            
           
            Console.WriteLine(output); }   }
    // Beware of syntax error like curly braces all that. But the concept is here. You may create Scan function by periodically invoking this process. Correct me if something goes wrong. 
