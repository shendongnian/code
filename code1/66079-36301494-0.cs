       Process[] my = Process.GetProcessesByName("mstsc");
       int pid = my[0].Id;
       Process pro = Process.GetProcessById(pid);
       pro.Kill();
       
