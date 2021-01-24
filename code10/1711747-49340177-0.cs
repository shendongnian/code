    class Program : Application
    {
        public Program()
        {
            InitializeComponent();
        }
    
        [STAThread]
        public static void Main()
        {
            LoginWindow loginWindow = new LoginWindow();
            /* Here you can set loginWindow's DataContext */ 
            Program app = new Program();
            app.Run(window);
        }
    }
