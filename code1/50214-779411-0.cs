    // Get the parameters/arguments passed to program if any
    string arguments = string.Empty;
    string[] args = Environment.GetCommandLineArgs();
    for (int i = 1; i < args.Length; i++) // args[0] is always exe path/filename
        arguments += args[i] + " ";
    // Restart current application, with same arguments/parameters
    Application.Exit();
    System.Diagnostics.Process.Start(Application.ExecutablePath, arguments);
