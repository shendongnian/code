    using CSharpTest.Net.Processes;
    partial class Program
    {
        static int Main(string[] args)
        {
         
            ProcessRunner run = new ProcessRunner("svn.exe");
            run.OutputReceived += new ProcessOutputEventHandler(run_OutputReceived);
            return run.Run("update", "C:\\MyProject");
        }
         
        static void run_OutputReceived(object sender, ProcessOutputEventArgs args)
        {
            Console.WriteLine("{0}: {1}", args.Error ? "Error" : "Output", args.Data);
        }
    }
