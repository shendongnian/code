     var processId = process.Id;
            process = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            process = System.Diagnostics.Process.GetProcessById(processId);
