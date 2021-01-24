    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
            this.Visible = false; // or set this on the designer.
        }
    
        public mainform_Load(object sender, EventArgs e)
        {
            SplashScreen ss = new SplashScreen();
            SplashScreen.ShowDialog();
            this.Visible = true;
        }
    }
