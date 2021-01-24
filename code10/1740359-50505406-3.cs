    public partial class FormSettings : Form
    {
        private FormMain formMain;
    
        public FormSettings(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }
    
        private void FormSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F1)
            {
                this.Close();
                formMain.Show();
            }
        }
    }
