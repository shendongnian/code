    private void Form1_Load(object sender, EventArgs e)
    {
      var wmiQueryString = "SELECT * FROM Win32_Process";
      //  var wmiQueryString = "SELECT * FROM Win32_ComputerSystem";
      using (var searcher = new ManagementObjectSearcher(wmiQueryString))
      using (var results = searcher.Get())
      {
        var query = from p in Process.GetProcesses()
                    join mo in results.Cast<ManagementObject>()
                    on p.Id equals (int)(uint)mo["ProcessId"]
                    select new
                    {
                      Process = p.ProcessName,
                      Path = (string)mo["ExecutablePath"],
                      CommandLine = (string)mo["CommandLine"],
                      User = GetProcessOwner(p.Id),
                      Description = GetDescription((string)mo["ExecutablePath"])
                    };
        dt = ConvertToDataTable(query);
        dataGridView1.DataSource = dt;
      }
    }
    string GetDescription(string executablePath)
    {
      if (!File.Exists(executablePath))
      {
        return "No Description";
      }
      return FileVersionInfo.GetVersionInfo(executablePath).FileDescription;
    }
