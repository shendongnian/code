    private static void Main()
    {
        var process = Process.GetProcessesByName("AcroRd32").FirstOrDefault();
        if (process != null)
        {
            Process.Start(@"C:\mvvm.pdf");
        }
        else
        {
            process = Process.Start(@"C:\mvvm.pdf");
        }
        process.EnableRaisingEvents = true;
        process.Exited += (sender, args) =>
        {
            Console.WriteLine("Exited");
        };
        Console.ReadLine();
    }
