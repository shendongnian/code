    using (TextWriter tw = new StreamWriter(@"C:\Users\Public\Documents\Info.txt"))
    {
        foreach (Process p in processes)
        {
            if (!String.IsNullOrEmpty(p.ProcessName))
            {
                var processTitle= !string.IsNullOrEmpty(p.MainWindowTitle) ? p.MainWindowTitle: "N/A";
                tw.WriteLine(string.Format("Process Name: {0} \t\t Process GUI Title:{1}",p.ProcessName, processTitle));
            }
        }
    }
