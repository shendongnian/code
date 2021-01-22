        static void Main(string[] args)
        {
            ServerManager mgr = new ServerManager();
            foreach(Site s in mgr.Sites)
            {
                Console.WriteLine("Site {0}", s.Name);
                foreach(Application app in s.Applications)
                {
                    Console.WriteLine("\tApplication: {0}", app.Path);
                    foreach(VirtualDirectory virtDir in app.VirtualDirectories)
                    {
                        Console.WriteLine("\t\tVirtual Dir: {0}", virtDir.Path);
                    }
                }
            }
            Console.ReadLine();
        }
