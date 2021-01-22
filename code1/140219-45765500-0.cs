        public void AppStartup (object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        public System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = null;
            try
            {
                bytes = (byte[])rm.GetObject(dllName);
            }
            catch (Exception ex)
            {
            }
            if (bytes != null)
            {
                // the following call will return a newly loaded assembly
                //   every time it is called
                // if this function is called more than once for the same
                //   assembly, you'll load more than one copy into memory
                // this can cause the InvalidCastException
                // instead of doing this, you keep a global list of loaded
                //   assemblies, and return the previously loaded assembly
                //   handle, instead of loading it again
                return System.Reflection.Assembly.Load(bytes);
            }
            return null;
        }
