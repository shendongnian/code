        await Task.Run(() =>
        {
            List<ProcessDiagnosticInfo> processList = ProcessDiagnosticInfo.GetForProcesses().ToList();
            processList.ForEach(o => Debug.WriteLine(o.ExecutableFileName));
        });
