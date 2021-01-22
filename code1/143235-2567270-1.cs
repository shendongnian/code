    public partial class SomeForm : Form
    {
        public SomeForm()
        {
            InitializeComponent();
            Controls.Add(new UserControl()
                         {
                             Location = new Point(10, 100),
                             BackColor = Color.Aquamarine,
                         });
        }
        private void increaseFontSizeButton_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 1.20f * this.Font.Size);
        }
    }
