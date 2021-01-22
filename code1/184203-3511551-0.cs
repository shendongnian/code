    Process[] prs = Process.GetProcessesByName("notepad");
    foreach (Process p in prs)
    {
    	string title = p.MainWindowTitle;
    	Console.WriteLine(title.Substring(0, title.IndexOf('-') -1));
    }
