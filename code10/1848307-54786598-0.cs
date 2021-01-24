           //Create don't kill processes
            var dontkill = new List<Process>();
            Process[] procs = Process.GetProcessesByName("EXCEL");
            foreach (Process p in procs)
            {
                dontkill.Add(p);
            }
            //EXCEL CODE HERE.
            xlWorkbook.Close();
            xlApp.Quit();
            //Now kill only the created process above.
            procs = Process.GetProcessesByName("EXCEL");
            foreach (Process p in procs)
            {
                if( !dontkill.Contains(p))
                {
                    p.Kill();
                }
            }
            Marshal.FinalReleaseComObject(xlApp);
