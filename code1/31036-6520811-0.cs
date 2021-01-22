    class CommandLineArgs
    {
        public static CommandLineArgs I
        {
            get
            {
                return m_instance;
            }
        }
        public	string argAsString( string argName )
        {
            if (m_args.ContainsKey(argName)) {
                return m_args[argName];
            }
            else return "";
        }
        public long argAsLong(string argName)
        {
            if (m_args.ContainsKey(argName))
            {
                return Convert.ToInt64(m_args[argName]);
            }
            else return 0;
        }
        public double argAsDouble(string argName)
        {
            if (m_args.ContainsKey(argName))
            {
                return Convert.ToDouble(m_args[argName]);
            }
            else return 0;
        }
        public void parseArgs(string[] args, string defaultArgs )
        {
            m_args = new Dictionary<string, string>();
            parseDefaults(defaultArgs );
            foreach (string arg in args)
            {
                string[] words = arg.Split('=');
                m_args[words[0]] = words[1];
            }
        }
        private void parseDefaults(string defaultArgs )
        {
            if ( defaultArgs == "" ) return;
            string[] args = defaultArgs.Split(';');
            foreach (string arg in args)
            {
                string[] words = arg.Split('=');
                m_args[words[0]] = words[1];
            }
        }
        private Dictionary<string, string> m_args = null;
        static readonly CommandLineArgs m_instance = new CommandLineArgs();
    }
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineArgs.I.parseArgs(args, "myStringArg=defaultVal;someLong=12");
            Console.WriteLine("Arg myStringArg  : '{0}' ", CommandLineArgs.I.argAsString("myStringArg"));
            Console.WriteLine("Arg someLong     : '{0}' ", CommandLineArgs.I.argAsLong("someLong"));
        }
    }
