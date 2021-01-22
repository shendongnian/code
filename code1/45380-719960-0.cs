    app.Quit(Access.AcQuitOption.acQuitSaveAll);
    if (!accessProcess.HasExited)
    {
        Console.WriteLine("Access did not exit after being asked nicely, killing process manually");
        accessProcess.Kill();
    }
