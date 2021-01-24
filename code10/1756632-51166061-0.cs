    public static Form1 from;  //<--- important
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           using (Form1 mainForm = new Form1())
           {
               from = mainForm;
                    
               Application.Run(from);
           }
    }
