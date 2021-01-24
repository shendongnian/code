    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void f2_ClearTextBoxOfForm(Form targetForm)
        {
            foreach (Control control in targetForm.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
            }
        }
        private void btnShowForm2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ClearTextBoxOfForm += f2_ClearTextBoxOfForm;
            f2.Show();
        }
    }
