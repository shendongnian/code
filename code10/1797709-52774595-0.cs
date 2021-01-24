    static class UnmanagedExport
    {
        [DllExport]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        static object CreateBroker()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            return new Class1();
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string path = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var assemblyname = "ClassLibrary2";
            return Assembly.LoadFrom($@"{path}\{assemblyname}.dll");
        }
    }
