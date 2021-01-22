    public static class RuntimeCodeCompiler
    {
        private static volatile Dictionary<string, Assembly> cache = new Dictionary<string, Assembly>();
        private static object syncRoot = new object();
        static Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();
        static RuntimeCodeCompiler()
        {
            AppDomain.CurrentDomain.AssemblyLoad += (sender, e) =>
            {
                assemblies[e.LoadedAssembly.FullName] = e.LoadedAssembly;
            };
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                Assembly assembly = null;
                assemblies.TryGetValue(e.Name, out assembly);
                return assembly;
            };
        }
        
        public static Assembly CompileCode(string code)
        {
            
            Microsoft.CSharp.CSharpCodeProvider provider = new CSharpCodeProvider();
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters compilerparams = new CompilerParameters();
            compilerparams.GenerateExecutable = false;
            compilerparams.GenerateInMemory = false;
            
            
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    string location = assembly.Location;
                    if (!String.IsNullOrEmpty(location))
                    {
                        compilerparams.ReferencedAssemblies.Add(location);
                    }
                }
                catch (NotSupportedException)
                {
                    // this happens for dynamic assemblies, so just ignore it. 
                }
            } 
            
            CompilerResults results =
               compiler.CompileAssemblyFromSource(compilerparams, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                foreach (CompilerError error in results.Errors)
                {
                    errors.AppendFormat("Line {0},{1}\t: {2}\n",
                           error.Line, error.Column, error.ErrorText);
                }
                throw new Exception(errors.ToString());
            }
            else
            {
                AppDomain.CurrentDomain.Load(results.CompiledAssembly.GetName());
                return results.CompiledAssembly;
            }
        }
        public static Assembly CompileCodeOrGetFromCache(string code,  string key)
        {
            bool exists = cache.ContainsKey(key);
            if (!exists)
            {
                lock (syncRoot)
                {
                    exists = cache.ContainsKey(key);
                    if (!exists)
                    {
                        cache.Add(key, CompileCode(code));
                    }
                }
            }
            return cache[key];
        }
       
    }
