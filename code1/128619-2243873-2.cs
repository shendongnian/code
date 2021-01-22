    class Program : ServiceBase
    {
        private string startupParam;
        static void Main(string[] args)
        {
            string arg = args[0];
            ServiceBase.Run(new Program(arg));
        }
        public Program(string startupParam)
        {
            this.ServiceName = "MyService";
            this.startupParam = startupParam;
        }
        ...
    }
