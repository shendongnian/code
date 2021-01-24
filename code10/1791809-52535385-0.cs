        public static void ListAllProcess()
        {
            int processCount = 0;
            Process[] processList = Process.GetProcesses();
            // view All running process
            foreach (Process process in processList)
            {
                Console.WriteLine("Process: {0} <> ID: {1}", process.ProcessName, process.Id);
                processCount += 1;
            }
            Console.WriteLine("Number of Total Process: {0} ", processCount);
        }
        static void Main(string[] args)
        {
            // view All running process..
            ListAllProcess();
            try
            {
                // for Start a new Process
                Console.Write("\n\nDrag-Drop or enter a full path of a executable file: ");
                string applicationPath = Console.ReadLine();
                Process.Start(applicationPath);
                Console.WriteLine("'{0}' is started.", applicationPath);
                // This start program itself. Don't try this...
                // string appPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                // System.Diagnostics.Process.Start(appPath);
                Console.Write("\n\n\n");
                ListAllProcess();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: '{0}'", ex);
            }
            try
            {
                // for kill a running Process
                Console.Write("\n\nEnter a Process ID:");
                int processID = Convert.ToInt32(Console.ReadLine());
                Process.GetProcessById(processID).Kill();
                Console.WriteLine("Process '{0}' died.", processID);
                Console.Write("\n\n\n");
                ListAllProcess();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: '{0}'", ex);
            }
            Console.ReadLine();
        }
