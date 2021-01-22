    public class CompilerRunner : MarshalByRefObject
    {
        private Assembly assembly = null;
        public void PrintDomain()
        {
            Console.WriteLine("Object is executing in AppDomain \"{0}\"",
                AppDomain.CurrentDomain.FriendlyName);
        }
        public bool Compile(string code)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
            parameters.ReferencedAssemblies.Add("system.dll");
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code);
            if (!results.Errors.HasErrors)
            {
                this.assembly = results.CompiledAssembly;
            }
            else
            {
                this.assembly = null;
            }
            return this.assembly != null;
        }
        public object Run(string typeName, string methodName, object[] args)
        {
            Type type = this.assembly.GetType(typeName);
            return type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, assembly, args);
        }
    }
