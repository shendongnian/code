    public static bool EnableHibernate()
    {
        Process p = new Process();
        p.StartInfo.FileName = "powercfg.exe";
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        p.StartInfo.Arguments = "/hibernate on"; // this might be different in other locales
        return p.Start();
    }
