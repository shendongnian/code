    static class UnmanagedExport
    {
        static UnmanagedExport()
            => AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            => Assembly.LoadFrom($@"{new FileInfo(args.RequestingAssembly.Location).DirectoryName}\{args.Name.Split(',')[0]}.dll");
        [DllExport]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        static object CreateBroker()
            => new Class1();
    }
