    Microsoft.VisualBasic.Interaction.Shell(@"cmd.exe /c ""start cmd.exe /k title NEWWINDOW""", AppWinStyle.NormalFocus);
    foreach (var process in Process.GetProcessesByName("cmd"))
    {
        if (process.MainWindowTitle.EndsWith("NEWWINDOW"))
        {
            process.Exited += ((o, e) => Console.WriteLine("Exit"));
            process.EnableRaisingEvents = true;
        }
    }
