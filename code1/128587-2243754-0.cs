    class Program
    {
        static void Main(string[] args)
        {
            var assemblyFilename = args.FirstOrDefault();
            if(assemblyFilename != null && File.Exists(assemblyFilename))
            {
                try
                {
                    var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFilename);
                    var name = assembly.GetName();
                    using(var file = File.AppendText("C:\\AssemblyInfo.txt"))
                    {
                        file.WriteLine("{0} - {1}", name.FullName, name.Version);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
