        var psi = new ProcessStartInfo();
        psi.FileName = @"C:\PythonInstall\python.exe";
        // 2) Provide script and arguments
        var script = @"C:\AllTech\Code\DaysBetweenDates.py";
        var start = "2019-1-1";
        var end = "2019-1-22";
        psi.Arguments = $"\"{script}\" \"{start}\" \"{end}\"";
        // 3) Process configuration
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        // 4) Execute process and get output
        var errors = "";
        var results = "";
        using(var process = Process.Start(psi))
        {
            errors = process.StandardError.ReadToEnd();
            results = process.StandardOutput.ReadToEnd();
        }
        // 5) Display output
        Console.WriteLine("ERRORS:");
        Console.WriteLine(errors);
        Console.WriteLine();
        Console.WriteLine("Results:");
        Console.WriteLine(results);
