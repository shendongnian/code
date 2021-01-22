static class Program
{
    // The main entry point for the application.
    static void Main(string[] args)
    {
        ServiceBase[] ServicesToRun;
        if ((args.Length > 0) && (args[0] == "/console"))
        {
            // Run the console version here
        }
        else
        {
            ServicesToRun = new ServiceBase[] { new serviceSample () };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
</pre>
