    class Program
    {
        static void Main(string[] args)
        {
            AppDomain appDomain = AppDomain.CreateDomain("MyTemp");
            appDomain.DoCallBack(loadAssembly);
            appDomain.DomainUnload += appDomain_DomainUnload;
            AppDomain.Unload(appDomain);
            AppDomain appDomain2 = AppDomain.CreateDomain("MyTemp2");
            appDomain2.DoCallBack(loadAssembly);
        }
        private static void loadAssembly()
        {
            string fullPath = "LoadMe1.dll";
            var assembly = Assembly.LoadFrom(fullPath);
            foreach (Type type in assembly.GetExportedTypes())
            {
                foreach (MemberInfo memberInfo in type.GetMembers())
                {
                    string name = memberInfo.Name;
                    Console.Out.WriteLine("name = {0}", name);
                }
            }
        }
        private static void appDomain_DomainUnload(object sender, EventArgs e)
        {
            Console.Out.WriteLine("unloaded");
        }
    }
