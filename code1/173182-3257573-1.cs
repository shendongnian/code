    /// <summary>
        /// This is the calling application.  The one where u currently have System.Diagnostics.Process
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                System.Diagnostics.Process p = new Process();
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = @"C:\AppfolderThing\ConsoleApplication1.exe";
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
    
    
                p.Start();            
                p.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
                {
                    Console.WriteLine("Output received from application: {0}", e.Data);
                };
                p.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
                {
                    Console.WriteLine("Output received from application: {0}", e.Data);
                };
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                StreamWriter inputStream = p.StandardInput;
                inputStream.WriteLine(1);
                inputStream.WriteLine(2);
                inputStream.WriteLine(-1);//tell it to exit
                p.WaitForExit();
            }
    
        }
