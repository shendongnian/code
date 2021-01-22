    static class Program
    {
        static void Main(string[] args)
        {
            if (Array.Exists(args, delegate(string arg) { return arg == "/install"; }))
            {
                System.Configuration.Install.TransactedInstaller ti = null;
                ti = new System.Configuration.Install.TransactedInstaller();
                ti.Installers.Add(new ProjectInstaller());
                ti.Context = new System.Configuration.Install.InstallContext("", null);
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                ti.Context.Parameters["assemblypath"] = path;
                ti.Install(new System.Collections.Hashtable());
                return;
            }
            if (Array.Exists(args, delegate(string arg) { return arg == "/uninstall"; }))
            {
                System.Configuration.Install.TransactedInstaller ti = null;
                ti = new System.Configuration.Install.TransactedInstaller();
                ti.Installers.Add(new ProjectInstaller());
                ti.Context = new System.Configuration.Install.InstallContext("", null);
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                ti.Context.Parameters["assemblypath"] = path;
                ti.Uninstall(null);
                return;
            }
            if (Array.Exists(args, delegate(string arg) { return arg == "/service"; }))
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new MyService() };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Console.ReadKey();
            }
        }
    }
