    class Program
    {
        /// <summary>
        /// Kill specified process and all child processes
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: KillProcessTree <pid>");
                return;
            }
            int pid = int.Parse(args[0]);
            Process root = Process.GetProcessById(pid);
            if (root != null)
            {
                Console.WriteLine("KillProcessTree " + pid);
                var list = new List<Process>();
                GetProcessAndChildren(Process.GetProcesses(), root, list, 1);
                // kill each process
                foreach (Process p in list)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Unknown process id: " + root);
            }
        }
        /// <summary>
        /// Get process and children
        /// We use postorder (bottom up) traversal; good as any when you kill a process tree </summary>
        /// </summary>
        /// <param name="plist">Array of all processes</param>
        /// <param name="parent">Parent process</param>
        /// <param name="output">Output list</param>
        /// <param name="indent">Indent level</param>
        private static void GetProcessAndChildren(Process[] plist, Process parent, List<Process> output, int indent)
        {
            foreach (Process p in plist)
            {
                if (p.GetParentProcessId() == parent.Id)
                {
                    GetProcessAndChildren(plist, p, output, indent + 1);
                }
            }
            output.Add(parent);
            Console.WriteLine(String.Format("{0," + indent*4 + "} {1}", parent.Id, parent.MainModule.ModuleName));
        }
    }
    } // namespace
