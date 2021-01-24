    public partial class InfoSettings : UserControl
    {
        public InfoSettings()
        {
            InitializeComponent();
        }
        private void settingBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1) this.Parent;
            form1.buttonHandler(sender);
        }
    }
