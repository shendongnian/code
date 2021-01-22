        static void Main(string[] args)
        {
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
                var currentAssembly = Assembly.GetExecutingAssembly();
                var otherDomain = AppDomain.CreateDomain("other domain");
                var ret = otherDomain.ExecuteAssemblyByName(
                                            currentAssembly.FullName,
                                            currentAssembly.Evidence,
                                            args);
                Environment.ExitCode = ret;
                return;
            }
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Hello");
        }
