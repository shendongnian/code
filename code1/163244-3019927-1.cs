    public static void Main()
    {
      Process process = Process.Start("leaker.exe");
      process.Kill();
    }
