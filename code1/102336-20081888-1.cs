    using System;
    namespace MyNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (ProcessPort p in ProcessPorts.ProcessPortMap.FindAll(x => x.ProcessName.ToLower() == "myprocess"))  //extension is not needed.
                {
                    Console.WriteLine(p.ProcessPortDescription);
                }
                foreach (ProcessPort p in ProcessPorts.ProcessPortMap.FindAll(x => x.PortNumber == 4444))
                {
                    Console.WriteLine(p.ProcessPortDescription);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
