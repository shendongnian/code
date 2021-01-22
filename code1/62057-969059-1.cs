    using System;
    using Microsoft.Win32;
    
    namespace MyApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                RegistryKey adobe = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Adobe");
                if(null == adobe)
                {
                    var policies = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Policies");
                    if (null == policies)
                        return;
                    adobe = policies.OpenSubKey("Adobe");
                }
                if (adobe != null)
                {
                    RegistryKey acroRead = adobe.OpenSubKey("Acrobat Reader");
                    if (acroRead != null)
                    {
                        string[] acroReadVersions = acroRead.GetSubKeyNames();
                        Console.WriteLine("The following version(s) of Acrobat Reader are installed: ");
                        foreach (string versionNumber in acroReadVersions)
                        {
                            Console.WriteLine(versionNumber);
                        }
                    }
                }
            }
        }
    }
