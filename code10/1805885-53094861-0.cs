    public partial class Form1 : Form
    {
        private int initialHeight;
        private int initialWidth;
        public Form1()
        {
            InitializeComponent();
            initialHeight = this.Size.Height;
            initialWidth = this.Size.Width;
        }
        private void chkResize_CheckedChanged(object sender, EventArgs e)
        {
            if(chkResize.Checked)
                this.Size = new Size(initialWidth, 500);
            else
                this.Size = new Size(initialWidth, initialHeight);
        }
    }
