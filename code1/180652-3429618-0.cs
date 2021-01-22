    static void Main(string[] args)
    {
        string pathToFile = "...";
        var processStartInfo = new ProcessStartInfo(); 
        processStartInfo.Verb = "print";
        processStartInfo.FileName = pathToFile;     
        var process = Process.Start(processStartInfo);
        process.WaitForExit();
    }
