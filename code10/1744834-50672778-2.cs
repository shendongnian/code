    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void f2_ClearTextBoxOfMainForm(object sender, EventArgs e)
        {
            Form frm = (Form)sender;
            foreach (Control control in frm.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
            }
        }
        private void btnShowForm2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ClearTextBoxOfMainForm += f2_ClearTextBoxOfMainForm;
            f2.Show();
        }
    }
