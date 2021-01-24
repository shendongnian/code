    namespace Automation_v1_0_0
    {
        public partial class FormMain : Form
        {    
            public FormMain()
            {
                InitializeComponent();
            }
    
            private void FormMain_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.F7)
                {
                    FormSettings settings = new FormSettings();
                     settings.ShowDialog();
                } 
            }
        }
    }
