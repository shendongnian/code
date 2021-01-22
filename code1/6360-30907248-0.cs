    using System.Diagnostics;
    ....
    [STAThread]
    static void Main()
    {
    ...
            foreach (Process pp in Process.GetProcesses())
            {
                try
                {
                    if (String.Compare(pp.MainModule.FileName, Application.ExecutablePath, true) == 0)
                    {                        
                        Application.Exit();
                        return;
                    }
                }
                catch { }
            }
            Application.Run(new Form1());
    }
