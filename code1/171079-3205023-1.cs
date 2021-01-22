    static void Main(string[] args)
      {
         Tool.Args = args;
    
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Download_Tool());
    
         Environment.ExitCode = Tool.ErrorCode;
      }
