    class Program
    {
        static void Main(string[] args)
        {
            var options = new ConnectionOptions();
            if (Environment.Is64BitProcess)
            {
                Console.WriteLine("Please run this sample as 32-bit");
                return;
            }
            // default behavior, should be 32-bit WMI provider since we build as x86
            Console.WriteLine("Print 32-bit aliases");
            PrintAliases(options);
            
            // also prints 32-bit aliases
            options.Context.Add("__ProviderArchitecture", 32);
            PrintAliases(options);
            // specify the 64-bit arch
            if (Environment.Is64BitOperatingSystem)
            {
                Console.WriteLine("Print 64-bit aliases");
                options.Context.Add("__ProviderArchitecture", 64);
                PrintAliases(options);
            }
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
