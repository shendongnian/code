    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
    
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormThatDividesByZero());            
    
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageDialog.Show(ex.Message);
            Application.Exit();
        }
        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageDialog.Show(e.Exception.Message);
        }
    }
    
   
    public partial class FormThatDividesByZero : Form
    {
        public FormThatDividesByZero()
        {
            InitializeComponent();
        }
    
        private void DivideByZeroButton_Click(object sender, EventArgs e)
        {
            // Create a divide by zero exception.
            int a = 0;
            int b = 0;
            int c = a / b;
        }
    }
