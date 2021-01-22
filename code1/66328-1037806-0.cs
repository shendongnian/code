<pre>internal class MyService : ServiceBase
{
    internal static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            // run as a service....
            ServiceBase[] servicesToRun = new ServiceBase[] {new MyService()};
            Run(servicesToRun);
        }
        else
        {
            // run as a console application....
        }
    }
}
</pre>
