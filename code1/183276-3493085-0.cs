        static void Main(string[] args)
        {
            var options = new ConnectionOptions();
            if (Environment.Is64BitOperatingSystem && Environment.Is64BitProcess == false)
            {
                Console.WriteLine("Please build as AnyCPU or x64");
                return;
            }
            // default behavior, should be 64-bit WMI provider
            Console.WriteLine("Print 64-bit aliases");
            PrintAliases(options);
            // specify the 32-bit arch
            Console.WriteLine("Print 32-bit aliases");
            options.Context.Add("__ProviderArchitecture", 32);
            PrintAliases(options);
        }
        private static void PrintAliases(ConnectionOptions options)
        {
            var scope = new ManagementScope(@"\\.\root\Microsoft\SqlServer\ComputerManagement10", options);
            try
            {
                scope.Connect();
            }
            catch
            {
                scope = new ManagementScope(@"\\.\root\Microsoft\SqlServer\ComputerManagement");
            }
            var clientAlias = new ManagementClass(scope, new ManagementPath("SqlServerAlias"), null);
            clientAlias.Get();
            foreach (ManagementObject existingAlias in clientAlias.GetInstances())
            {
                existingAlias.Get();
                var propertiesToRead = new[] { "AliasName", "ServerName", "ProtocolName", "ConnectionString" };
                foreach (var propertyToRead  in propertiesToRead)
                {
                    Console.WriteLine("Property {0} = {1}", propertyToRead, existingAlias.GetPropertyValue(propertyToRead));
                }
            }
        }
