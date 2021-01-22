     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.IO;
    using System.Threading;
    namespace Haart_Trainer_App
    {
        class ProcessRunner
        {
            private string process = "";
            private string args = "";
            private ListBox output = null;
            private Thread t = null;
        public ProcessRunner(string process, string args, ref ListBox output)
        {
            this.process = process;
            this.args = args;
            this.output = output;
            t = new Thread(new ThreadStart(this.execute));
            t.Start();
       
        }
        private void execute()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = process;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            string outmsg;
            try
            {
                StreamReader read = proc.StandardOutput;
            
            while ((outmsg = read.ReadLine()) != null)
            {
               
                    lock (output)
                    {
                        output.Items.Add(outmsg);
                    }
                
            }
            }
            catch (Exception e) 
            {
                lock (output)
                {
                    output.Items.Add(e.Message);
                }
            }
            proc.WaitForExit();
            var exitCode = proc.ExitCode;
            proc.Close();
        }
    }
}
