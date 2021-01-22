    static void Main(string[] args) {
      Console.WriteLine(
        System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
      Console.WriteLine(
        System.Reflection.Assembly.GetEntryAssembly().Location);
    }
