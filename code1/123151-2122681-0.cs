    int pid = Interaction.Shell("notepad.exe", AppWinStyle.NormalFocus);
    Process p = Process.GetProcessById(pid);
    p.Exited += ((o, e) => Console.WriteLine("Exit"));
    p.EnableRaisingEvents = true;
    Console.ReadLine();
