    public partial class Form1 : Form
    {
        Color defaultColor;
        Color hoverColor = Color.Orange;
        public Form1()
        {
            InitializeComponent();
            defaultColor = button1.BackColor;
        }
        private void Form1_MouseHover(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.BackColor = hoverColor;
                }
            }
        }
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.BackColor = defaultColor;
                }
            }
        }
    }
