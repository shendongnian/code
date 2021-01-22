    Process[] processes = Process.GetProcesses();
      for (int i = 0; i < pros.Count(); i++)
     {
       if (processes[i].ProcessName.ToLower().Contains("powerpnt"))
            {
              processes[i].Kill();
            }
     }
