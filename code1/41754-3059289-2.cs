    class proxyDomain : MarshalByRefObject
    {
        public Assembly GetAssembly(string AssemblyPath)
        {
            try
            {
                return Assembly.LoadFrom(AssemblyPath);
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }
    }
