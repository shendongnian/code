    public partial class FormMain : Form
    {
        bool keysActivated = true;
    
        public FormMain()
        {
            InitializeComponent();
        }
    
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (keysActivated)
            {
                if (e.KeyCode == Keys.F7)
                {
                    this.Hide();
                    FormSettings settings = new FormSettings(this);
                    settings.Show();
                }
            }
        }
    }
