cs
        AppDomain.CurrentDomain.AssemblyResolve -= AssemblyResolveEventHandler;
        AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveEventHandler;
        private static readonly ResolveEventHandler AssemblyResolveEventHandler = (sender, resolveEventArgs) =>
        {
            var assemblyName = GetAssemblyName(resolveEventArgs.Name);
            var assemblyDllPath3 = Path.Combine(@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\PrivateAssemblies", $"{assemblyName}.dll");
            var assembly = (File.Exists(assemblyDllPath3) ? Assembly.LoadFrom(assemblyDllPath3) : null);
            return assembly;
        };
        internal static string GetAssemblyName(string fullAssemblyName)
        {
            const string AssemblyNamePattern = "^([^,]+)([,].+)*$";
            return Regex.Match(fullAssemblyName, AssemblyNamePattern).Groups[1].Value;
        }
