    static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            string assemblyName = new AssemblyName(args.Name).Name;
            if (assemblyName.EndsWith(".resources"))
                return null;
            string dllName = assemblyName + ".dll";
            string dllFullPath = Path.Combine(GetMyApplicationSpecificPath(), dllName);
            using (Stream s = Assembly.GetEntryAssembly().GetManifestResourceStream(typeof(Program).Namespace + ".Resources." + dllName))
            {
                byte[] data = new byte[stream.Length];
                s.Read(data, 0, data.Length);
                //or just byte[] data = new BinaryReader(s).ReadBytes((int)s.Length);
                File.WriteAllBytes(dllFullPath, data);
            }
            return Assembly.LoadFrom(dllFullPath);
        };
    }
