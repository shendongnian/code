    public static void Main()
    {
      Process process = Process.Start("MemoryHog.exe 6000 2000");
      process.Kill();
    }
