    public partial class Form1 : Form
    {
        private int initialHeight;
        public Form1()
        {
            InitializeComponent();
            initialHeight = this.Height;
        }
        private void chkResize_CheckedChanged(object sender, EventArgs e)
        {
            if(chkResize.Checked)
                this.Height = 500;
            else
                this.Height = initialHeight;
        }
    }
