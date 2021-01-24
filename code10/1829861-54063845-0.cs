        private static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var framework = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
            Console.WriteLine($"{assembly.GetName().ProcessorArchitecture.ToString()} - {framework}");
            Console.ReadLine();
        }
