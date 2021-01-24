      class ConnectionString
      {
        public string Conn { get; set; }
        public string Server { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
      }
      class MainClass
      {
        static int Main(string[] args)
        {
          // Test if input arguments were supplied:
          if (args.Length == 0)
          {
            System.Console.WriteLine("No parameters specified.");
            return 1;
          }
          if (args.Length % 4 != 0)
          {
            System.Console.WriteLine("Invalid number of parameters specified.");
            return 1;
          }
          List<ConnectionString> connections = new List<ConnectionString>():
          ConnectionString connec;
          for (int i = 0; i < args.Length; i += 4)
          {
            connec = new ConnectionString();
            connec.Conn = args[i];
            connec.Server = args[i + 1];
            connec.user = args[i + 2];
            connec.pass = args[i + 3];
            connections.Add(connec);
          }
          // Do what you need to do here
          return 0;
        }
      }
