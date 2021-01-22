    [RunInstaller(true)]
    public sealed class MyServiceInstallerProcess : ServiceProcessInstaller
    {
        public MyServiceInstallerProcess()
        {
            this.Account = ServiceAccount.NetworkService;
        }
    }
    [RunInstaller(true)]
    public sealed class MyServiceInstaller : ServiceInstaller
    {
        public MyServiceInstaller()
        {
            this.Description = "Service Description";
            this.DisplayName = "Service Name";
            this.ServiceName = "ServiceName";
            this.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
        }
    }
    static void Install(bool undo, string[] args)
    {
        try
        {
            Console.WriteLine(undo ? "uninstalling" : "installing");
            using (AssemblyInstaller inst = new AssemblyInstaller(typeof(Program).Assembly, args))
            {
                IDictionary state = new Hashtable();
                inst.UseNewContext = true;
                try
                {
                    if (undo)
                    {
                        inst.Uninstall(state);
                    }
                    else
                    {
                        inst.Install(state);
                        inst.Commit(state);
                    }
                }
                catch
                {
                    try
                    {
                        inst.Rollback(state);
                    }
                    catch { }
                    throw;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
