    public void WriteToConsole(string message)
    {
      AttachToConsole(-1);
      Console.WriteLine(message);
    }
    [DllImport("Kernel32.dll")]
    public static extern bool AttachConsole(int processId);
