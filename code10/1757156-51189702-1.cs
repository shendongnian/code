    try
    {
         //"The code you wanna try"
    }
    catch
    {
         System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0], Environment.GetCommandLineArgs().Length > 1 ? string.Join(" ", Environment.GetCommandLineArgs().Skip(1)) : null);</i>
    }
