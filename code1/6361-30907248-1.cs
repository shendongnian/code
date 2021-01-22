    using System.Diagnostics;
    ....
    [STAThread]
    static void Main()
    {
    ...
            int procCount = 0;
            foreach (Process pp in Process.GetProcesses())
            {
                try
                {
                    if (String.Compare(pp.MainModule.FileName, Application.ExecutablePath, true) == 0)
                    {
                        procCount++;                        
                        if(procCount > 1) {
                           Application.Exit();
                           return;
                        }
                    }
                }
                catch { }
            }
            Application.Run(new Form1());
    }
