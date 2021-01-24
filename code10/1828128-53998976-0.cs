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
            this.BackColor = Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
        }
    
        public void ToLightMode()
        {
            this.BackColor = Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
        }
    }
