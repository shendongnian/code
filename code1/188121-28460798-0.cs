    Console.Title = "MyConsole";
    System.Diagnostics.Process HideConsole = new System.Diagnostics.Process();
    HideConsole.StartInfo.UseShellExecute = false;
    HideConsole.StartInfo.Arguments = "MyConsole /hid";
    HideConsole.StartInfo.FileName = "cmdow.exe";
    HideConsole.Start();
