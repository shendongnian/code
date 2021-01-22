    using System;
    using System.IO;
    using System.Security.Permissions;
    using System.Collections.Generic;
    
    namespace MultiWatcher
    // ConsoleApplication, which monitors TXT-files in multiple folders. 
    // Inspired by:
    // http://msdn.microsoft.com/en-us/library/system.io.filesystemeventargs(v=vs.100).aspx
    
    {
        public class Watchers
        {
            public static void Main()
            {
                Run();
    
            }
    
            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            public static void Run()
            {
                string[] args = System.Environment.GetCommandLineArgs();
    
                // If a directory is not specified, exit program.
                if (args.Length < 2)
                {
                    // Display the proper way to call the program.
                    Console.WriteLine("Usage: Watcher.exe (directory)" + args.Length.ToString());
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 1; i < args.Length; i++)
                {
                    list.Add(args[i]);
                }
                foreach (string my_path in list)
                {
                    Watch(my_path);
                }
    
                // Wait for the user to quit the program.
                Console.WriteLine("Press \'q\' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
            private static void Watch(string watch_folder)
            {
                // Create a new FileSystemWatcher and set its properties.
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = watch_folder;
                /* Watch for changes in LastAccess and LastWrite times, and
                   the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";
    
                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
    
                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
    
            // Define the event handlers.
            private static void OnChanged(object source, FileSystemEventArgs e)
            {
                // Specify what is done when a file is changed, created, or deleted.
                Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            }
    
            private static void OnRenamed(object source, RenamedEventArgs e)
            {
                // Specify what is done when a file is renamed.
                Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            }
        }
    }
