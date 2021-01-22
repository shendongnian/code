            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey)) 
            { 
                var query = from a in 
                                key.GetSubKeyNames() 
                            let r = key.OpenSubKey(a) 
                            select new 
                            { 
                                Application = r.GetValue("DisplayName") 
                            };
                
                foreach (var item in query) 
                { 
                    if (item.Application != null)
                        Console.WriteLine(item.Application); 
                }
            }
