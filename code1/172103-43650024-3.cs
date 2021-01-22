    var options = new ProcessStartInfo()
    {
        FileName = "Serial Port Process name here",
        UseShellExecute = false,
        RedirectStandardOutput = true,
    };
    using(var process = Process.Start(options))
    {
        using (StreamReader reader = process.StandardOutput)
        {
            while (!process.HasExited)
            {
                string result = reader.ReadLine();
                Console.WriteLine(result);
            }
        }
    }
