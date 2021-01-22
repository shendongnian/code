    static void Main(string[] args)
    {
        string pathToFile = "...";
        var processStartInfo = new ProcessStartInfo(); 
        processStartInfo.Verb = "print";
        processStartInfo.FileName = pathToFile;     
        var process = Process.Start(processStartInfo);
        
        System.Threading.Thread.Sleep(1000);
        System.Windows.Forms.SendKeys.SendWait("{ENTER}");
        process.WaitForExit();
    }
