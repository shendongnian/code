        static void Main()
        {
            const string dotNetFourPath = "Software\\Microsoft";//note backslash
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(dotNetFourPath))
            {
                Console.WriteLine(registryKey.SubKeyCount);//registry is not null
                foreach (var VARIABLE in registryKey.GetSubKeyNames())
                {
                    Console.WriteLine(VARIABLE);//here I can see I have many keys
                    //no need to switch to x64 as suggested on other posts
                }
            }
        }
