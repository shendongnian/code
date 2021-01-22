    class Program
    {
        public static readonly MainForm MainForm;
    
        static void Main()
        {
            Application.EnableVisualStyles();
            MainForm = new MainForm(); // These two lines
            Application.Run(MainForm); // are the important ones.
        }
    }
