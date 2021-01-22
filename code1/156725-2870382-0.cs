    namespace ConsoleApplication
    {
        #region Imports
        using System;
        using System.IO;
        using System.Security;
        using System.Security.Permissions;
    
        #endregion
        public class Plugin : MarshalByRefObject
        {        
            public string TestRead(string path)
            {
                try
                {
                    File.ReadAllBytes(path);
                    return "Done";
                }
                catch (SecurityException)
                {
                    return "Access Denied";
                }
            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                var setup = new AppDomainSetup();
                
                setup.ApplicationBase = 
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                
                var perm = new PermissionSet(PermissionState.None);
                
                perm.AddPermission(
                    new SecurityPermission(
                        SecurityPermissionFlag.Execution));
                
                perm.AddPermission(
                    new FileIOPermission(
                        FileIOPermissionAccess.Read, "c:\\public\\"));
                
                var pluginDomain = 
                    AppDomain.CreateDomain("PluginDomain", null, setup, perm);
                
                var plugin = 
                    pluginDomain.CreateInstanceAndUnwrap(
                        typeof(Plugin).Assembly.FullName,
                        typeof(Plugin).FullName) as Plugin;
                Console.WriteLine(plugin.TestRead("c:\\public\\test.txt"));
                Console.WriteLine(plugin.TestRead("c:\\secret\\test.txt"));
                Console.ReadKey();
            }
        }
    }
