    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
               if (Properties.Settings.Default.test == 100)
                {
                    MessageBox.Show($"Properties.Settings.Default.test : {Properties.Settings.Default.test}");
                }
            }
        }
    }
