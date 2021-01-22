    public partial class ApplicationWindow : System.Windows.Forms.Form
    {
        public ApplicationWindow()
        {
            SplashForm.Show( 500 );
            InitializeComponent();
        }
        private void OnLoad( object sender, EventArgs e )
        {
            // Simulate doing a lot of work here.
            System.Threading.Thread.Sleep( 1000 );
            SplashForm.Hide();
            Show();
            Activate();
        }
    }
