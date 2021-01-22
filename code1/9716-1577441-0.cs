    Process[] prs = Process.GetProcesses();
    List<int> excelPID = new List<int>();
    foreach (Process p in prs)
       if (p.ProcessName == "EXCEL")
           excelPID.Add(p.Id);
    .... // your job 
    prs = Process.GetProcesses();
    foreach (Process p in prs)
       if (p.ProcessName == "EXCEL" && !excelPID.Contains(p.Id))
           p.Kill();
