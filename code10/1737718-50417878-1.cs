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
        List<ConnectionString> connections = new List<ConnectionString>():
            ConnectionString connec = null;
        for (int i = 0; i < args.Length; i++)
        {
          if (args[i].StartsWith("-s"))
          {
            if (connec != null)
            {
              connec.Server = args[i].Substring(2);
            }
            continue;
          }
          if (args[i].StartsWith("-u"))
          {
            if (connec != null)
            {
              connec.user = args[i].Substring(2);
            }
            continue;
          }
          if (args[i].StartsWith("-p"))
          {
            if (connec != null)
            {
              connec.pass = args[i].Substring(2);
            }
            continue;
          }
          connec = new ConnectionString();
          connec.Conn = args[i];
          connections.Add(connec);
        }
        // Do What you need to do from here
        return 0;
      }
    }
