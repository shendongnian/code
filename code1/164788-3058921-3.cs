    public void WriteToConsole(string message)
    {
      _connected = _connected || AttachConsole(-1);
      if(_connected)
        Console.WriteLine("Hello");
      else
        ... other way to output message ...
    }
    bool _connected;
    [DllImport("Kernel32.dll")]
    public static extern bool AttachConsole(int processId);
      
