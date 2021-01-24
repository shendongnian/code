    Process[] processes = Process.GetProcessesByName("EXCEL");
    Console.WriteLine("{0} Word processes", processes.Length);
    foreach (var process in processes)
    {
        process.Kill();
    }
    Console.WriteLine("All word processes killed!");
