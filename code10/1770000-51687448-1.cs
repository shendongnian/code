    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }
    
        public mainform_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            using (SplashScreen ss = new SplashScreen())
            {
                ss.ShowDialog();
                SetTheme(ss.LoadedTheme);
                this.Visible = true;
            }
        }
        private void SetTheme(Theme theme)
        {
            //Put your theme setting code here.
        }
    }
