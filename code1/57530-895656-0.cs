    NamedPipeServerStream s = new NamedPipeServerStream("p", PipeDirection.In);
    Action<NamedPipeServerStream> a = callBack;
    a.BeginInvoke(s, ar => { }, null);
    ...
    private void callBack(NamedPipeServerStream pipe)
    {
      while (true)
      {
        pipe.WaitForConnection();
        StreamReader sr = new StreamReader(pipe);
        Console.WriteLine(sr.ReadToEnd());
        pipe.Disconnect();
      }
    }
