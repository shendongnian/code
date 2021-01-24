    public partial class Form1 : Form
    {
        public Color OriginalBackground;
        public Form1()
        {
            InitializeComponent();
            foreach (var control in Controls.OfType<Label>())
            {
                control.MouseEnter += label_MouseEnter;
                control.MouseLeave += label_MouseLeave;
            }
        }
        private void label_MouseEnter(object sender, EventArgs e)
        {
            OriginalBackground = ((Label) sender).BackColor;
            ((Label) sender).BackColor = Color.Red;
        }
        private void label_MouseLeave(object sender, EventArgs e)
        {
            ((Label) sender).BackColor = OriginalBackground;
        }
    }
