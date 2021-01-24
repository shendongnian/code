        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);
             
    // you can’t edit OS because object already created
            comp.OS = OS.getInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);
             
            Console.ReadLine();
        }
    }
    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.getInstance(osName);
        }
    }
    class OS
    {
        private static OS instance;
     
        public string Name { get; private set; }
     
        protected OS(string name)
        {
            this.Name=name;
        }
     
        public static OS getInstance(string name)
        {
            if (instance == null)
                instance = new OS(name);
             return instance;
    }
    }
