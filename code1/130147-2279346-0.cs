    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProcessStartInfo info = 
                     new ProcessStartInfo("ErroneusApp.exe");
                info.ErrorDialog = false;
                info.RedirectStandardError = true;
                info.RedirectStandardOutput = true;
                info.CreateNoWindow = true;
                info.UseShellExecute = false;
                System.Diagnostics.Process p = 
                    System.Diagnostics.Process.Start(info);
                p.EnableRaisingEvents = true;
                p.Exited += p_Exited;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void p_Exited(object sender, EventArgs e)
        {
            Process p = sender as Process;
            if (p != null)
            {
                Console.WriteLine("Exited with code:{0} ", p.ExitCode);
            }
            else
                Console.WriteLine("exited");
        }
    }
