    using System;
    using System.IO;
    
    namespace TestCs
    {
        public class Program
        {
            // The app id must be unique. Generate a new guid for your application. 
            public static string AppId = "01234567-89ab-cdef-0123-456789abcdef";
    
            // The stream is stored globally to ensure that it won't be disposed before the application terminates.
            public static FileStream UniqueInstanceStream;
    
            public static int Main(string[] args)
            {
                EnsureUniqueInstance();
    
                // Your code here.
    
                return 0;
            }
    
            private static void EnsureUniqueInstance()
            {
				// Note: If you want the check to be per-user, use Environment.SpecialFolder.ApplicationData instead.
				string lockDir = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
					"UniqueInstanceApps");
				string lockPath = Path.Combine(lockDir, $"{AppId}.unique");
    
                Directory.CreateDirectory(lockDir);
    
                try
                {
                    // Create the file with exclusive write access. If this fails, then another process is executing.
                    UniqueInstanceStream = File.Open(lockPath, FileMode.Create, FileAccess.Write, FileShare.None);
    
                    // Although only the line above should be sufficient, when debugging with a vshost on Visual Studio
                    // (that acts as a proxy), the IO exception isn't passed to the application before a Write is executed.
                    UniqueInstanceStream.Write(new byte[] { 0 }, 0, 1);
                    UniqueInstanceStream.Flush();
                }
                catch
                {
                    throw new Exception("Another instance of the application is already running.");
                }
            }
        }
    }
