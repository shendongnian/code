    public partial class Form1 : Form
    {
        private string controlName = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            controlName = btn.Name;
            txtBox.Focus();
        }
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Controls[controlName].Focus();
            }
        }
    }
