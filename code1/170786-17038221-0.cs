    Process[] pros = Process.GetProcesses();
      for (int i = 0; i < pros.Count(); i++)
     {
       if (pros[i].ProcessName.ToLower().Contains("powerpnt"))
            {
              pros[i].Kill();
            }
     }
