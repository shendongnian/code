    public MyDerivedForm : Form
    {
        public MyDerivedForm()
        {
            InitializeComponent();
        }
        public void ChangeTheme(bool usedarkmode)
        {
            if (usedarkmode)
                ToDarkMode();
            else
                ToLightMode();
        }
        public void ToDarkMode()
        {
            this.BackColor = Color.FromArgb(28, 28, 28);
        }
    
        public void ToLightMode()
        {
            this.BackColor = Color.FromArgb(241, 241, 241);
        }
    }
