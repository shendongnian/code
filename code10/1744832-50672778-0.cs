    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void f2_ClearTextBoxOfMainForm(object sender, EventArgs e)
        {
            //here you can clear textboxes of main form
        }
        private void btnShowForm2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ClearTextBoxOfMainForm += f2_ClearTextBoxOfMainForm;
            f2.Show();
        }
    }
