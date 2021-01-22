    namespace AppStarter
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process process = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(args[0]);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.RedirectStandardInput = true;
                psi.Arguments = string.Join(" ", args, 1, args.Length - 1);
                process.StartInfo = psi;
                process.Start();
                Console.WriteLine("Process started with PID {0}", process.Id);
            }
        }
    }
