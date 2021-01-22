    private const string PipeName = "471450d6-70db-49dc-94af-09d3f3eba529";
    public static void Main(string[] args)
    {
        Console.WriteLine("Main program running");
        using (NamedPipeServerStream pipe = new NamedPipeServerStream(PipeName, PipeDirection.Out))
        {
            Process.Start("child.exe");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
