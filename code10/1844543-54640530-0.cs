        static void Main()
        {
            // set to true if running under Windows environmnet. 
            // set to false if running under Linux
            bool runningOnWindows = true;
            string filePath = runningOnWindows ? @"C:\Users\Antonio\Desktop\ome-GUID.process" : "/tmp/some-GUID.process";
            try
            {
                // Prevents other processes from reading from or writing to this file
                new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None).Lock(0, 0);
            }
            catch
            {
                Console.WriteLine("Another instance is running. Terminating application.");
                Environment.Exit(1); // terminate application
                return;
            }
            //  Perform your work in here
            Console.WriteLine("Doing work...");
            Thread.Sleep(10000);
        }     
