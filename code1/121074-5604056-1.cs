    static void Main(string[] args)
    {
        string filename = args[0];
        DateTime start = DateTime.Now;
        bool done = false;
        while ((DateTime.Now - start).TotalSeconds < 30 && !done)
        {
            try
            {
                StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
                string[] runData = new string[2];
                runData[0] = sr.ReadLine();
                runData[1] = sr.ReadLine();
                Thread.Sleep(1000);
                Process.Start(new ProcessStartInfo { FileName = runData[0], WorkingDirectory = runData[1] });
                sr.Dispose();
                File.Delete(filename);
                done = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(1000);
        }
    }
