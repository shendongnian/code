    public partial class SomeForm : Form
    {
        public SomeForm()
        {
            InitializeComponent();
            Controls.Add(new TextBox()
                         {
                             Location = new Point(10, 100),
                             Text = "TextBox added later"
                         });
        }
        private void increaseFontSizeButton_Click(object sender, EventArgs e)
        {
            this.Font = new Font(this.Font.FontFamily, 1.20f * this.Font.Size);
        }
    }
