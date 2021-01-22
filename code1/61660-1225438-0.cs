        private void PrintAssemblyInfo(string fullName)
        {
            string[] parts = fullName.Split(',');
            Console.WriteLine(" - {0}, {1}", parts[0], parts[3]);
        }
        private void GenerateInfo(string path)
        {
            foreach (var file in Directory.GetFiles(path, 
               "*.dll",
               SearchOption.AllDirectories))
            {
                try
                {
                    Assembly assembly = Assembly.ReflectionOnlyLoadFrom(file);
                    PrintAssemblyInfo(assembly.GetName().FullName);
                }
                catch { }
            }
        }
        private void GenerateInfo()
        {
            GenerateInfo(@"C:\Windows\Microsoft.NET\Framework\v2.0.50727");
            GenerateInfo(@"C:\Windows\Microsoft.NET\Framework\v3.0");
            GenerateInfo(@"C:\Windows\Microsoft.NET\Framework\v3.5");
        }
