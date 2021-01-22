    protected void Page_Load(object sender, EventArgs e)
    {
       AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolve);
       Assembly assembly = Assembly.Load("PhantomAssembly");
       Type t = assembly.GetType("PhantomAssembly.Test");
       MethodInfo m = t.GetMethod("GetIt");
       Response.Write(m.Invoke(null, null));
       t.GetMethod("IncrementIt").Invoke(null, null);
    }
    private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
    {
       Assembly asssembly = Assembly.Load(File.ReadAllBytes(@"C:\PhantomAssembly.dll"));
       return asssembly;
    }
