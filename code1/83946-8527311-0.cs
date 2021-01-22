            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);
                Assembly assembly = Assembly.ReflectionOnlyLoad("foo");
                foreach (Type t in assembly.GetTypes())
                {
                    Console.WriteLine(t.FullName);
                }
            }
    
            static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
            {
                return System.Reflection.Assembly.ReflectionOnlyLoad(args.Name);
            }
