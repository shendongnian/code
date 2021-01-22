    public void KillProcessesAssociatedToFile(string file)
        {
            GetProcessesAssociatedToFile(file).ForEach(x =>
            {
                x.Kill();
                x.WaitForExit(10000);
            });
        }
        public List<Process> GetProcessesAssociatedToFile(string file)
        {
            return Process.GetProcesses()
                .Where(x => !x.HasExited
                    && x.Modules.Cast<ProcessModule>().ToList()
                        .Exists(y => y.FileName.ToLowerInvariant() == file.ToLowerInvariant())
                    ).ToList();
        }
