static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyName = args.Name.Split(',').First();
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("YourNamespace." + assemblyName + ".dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }</pre></code>
In your main method put
AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;</pre>
