    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace PublicClass.Class
    {
      public  class RunAlready
        {
          public  string processIsRunning(string process)
            {
            string xdescription = "";
            System.Diagnostics.Process[] processes =
                System.Diagnostics.Process.GetProcessesByName(process);
            foreach (System.Diagnostics.Process proc in processes)
            {
                var iddd = System.Diagnostics.Process.GetCurrentProcess().Id;
                if (proc.Id != System.Diagnostics.Process.GetCurrentProcess().Id)
                {
                    xdescription = "Application Run At time:" + proc.StartTime.ToString() + System.Environment.NewLine;
                    xdescription += "Current physical memory : " + proc.WorkingSet64.ToString() + System.Environment.NewLine;
                    xdescription += "Total processor time : " + proc.TotalProcessorTime.ToString() + System.Environment.NewLine;
                    xdescription += "Virtual memory size : " +         proc.VirtualMemorySize64.ToString() + System.Environment.NewLine;
                }
            }
            
            return xdescription;
        }
    }
    }
