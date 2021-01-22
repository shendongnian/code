    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Reflection;
    
    namespace Version
    {
        class GetVersion
        {
            static void Main(string[] args)
            {
                if (args.Length == 0 || args.Length > 1) { ShowUsage(); return; }
                
                string target = args[0];
    
                string path = Path.IsPathRooted(target) 
                                    ? target 
                                    : Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + Path.DirectorySeparatorChar + target;
    
                Console.Write( Assembly.LoadFile(path).GetName().Version.ToString(2) );
            }
    
            static void ShowUsage()
            {
                Console.WriteLine("Usage: version.exe <target>");
            }
        }
    }
