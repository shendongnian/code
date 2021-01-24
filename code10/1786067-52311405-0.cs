    namespace ConsoleApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
               InitializeComponent();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                 DialogResult dialog = dialog = MessageBox.Show("Do you really want to close the program?", "SomeTitle", MessageBoxButtons.YesNo);
                 if (dialog == DialogResult.No)
                 {
                     e.Cancel = true;
                 }
            }
        }
    }
