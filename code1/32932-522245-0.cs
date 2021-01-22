    // In Your Program.cs Convert This
    static void Main()
    {
    	Application.EnableVisualStyles();
    	Application.SetCompatibleTextRenderingDefault(false);
    	Application.Run(new Form1());
    }
    
    // To This
    static void Main()
    {
    	Application.EnableVisualStyles();
    	Application.SetCompatibleTextRenderingDefault(false);
    	Form1 TheForm = new Form1();
    	Application.Run();
    }
    
    // Call Application.Exit() From Anywhere To Stop Application.Run() Message Pump and Exit Application
