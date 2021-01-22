    class Program
    {
        static void Main(string[] args)
        {
     
                Process[] processes = Process.GetProcessesByName("job Test");
                for (int p = 0; p < processes.Length; p++)
                {
                    String[] arguments = CommandLineUtilities.getCommandLinesParsed(processes[p]);
                }
                System.Threading.Thread.Sleep(10000);
        }
    }
    public abstract class CommandLineUtilities
    {
        public static String getCommandLines(Process processs)
        {
            ManagementObjectSearcher commandLineSearcher = new ManagementObjectSearcher(
                "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + processs.Id);
            String commandLine = "";
            foreach (ManagementObject commandLineObject in commandLineSearcher.Get())
            {
                 commandLine+= (String)commandLineObject["CommandLine"];
            }
            return commandLine;
        }
        public static String[] getCommandLinesParsed(Process process)
        {
            return (parseCommandLine(getCommandLines(process)));
        }
        /// <summary>
        /// This routine parses a command line to an array of strings
        /// Element zero is the program name
        /// Command line arguments fill the remainder of the array
        /// In all cases the values are stripped of the enclosing quotation marks
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns>String array</returns>
        public  static String[] parseCommandLine(String commandLine)
        {
            List<String> arguments = new List<String>();
            Boolean stringIsQuoted = false;
            String argString = "";
            for (int c = 0; c < commandLine.Length; c++)  //process string one character at a tie
            {
                if (commandLine.Substring(c, 1) == "\"")
                {
                    if (stringIsQuoted)  //end quote so populate next element of list with constructed argument
                    {
                        arguments.Add(argString);
                        argString = "";
                    }
                    else
                    {
                        stringIsQuoted = true; //beginning quote so flag and scip
                    }
                }
                else if (commandLine.Substring(c, 1) == "".PadRight(1))
                {
                    if (stringIsQuoted)
                    {
                        argString += commandLine.Substring(c, 1); //blank is embedded in quotes, so preserve it
                    }
                    else if (argString.Length > 0)
                    {
                        arguments.Add(argString);  //non-quoted blank so add to list if the first consecutive blank
                    }
                }
                else
                {
                    argString += commandLine.Substring(c, 1);  //non-blan character:  add it to the element being constructed
                }
            }
            return arguments.ToArray();
        }
    }
