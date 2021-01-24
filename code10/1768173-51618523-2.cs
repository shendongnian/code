    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            dynamic props = Properties.Settings.Default;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (props.test == 100)
                {
                    MessageBox.Show($"Properties.Settings.Default.test : {props.test}");
                }
            }
        }
    }
