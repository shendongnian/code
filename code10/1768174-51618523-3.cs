    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            dynamic props = Properties.Settings.Default;
            string Flippo1SN = "200";
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string output = "Properties.Settings.Default.test : ";
    
                if (Flippo1SN == props.test.ToString())
                {
                    output += $"{props.test}";
                }
                if (Flippo1SN == props.test2.ToString())
                {
                    output += $"{props.test2}";
                }
                if (Flippo1SN == props.test3.ToString())
                {
                    output += $"{props.test3}";
                }
    
                MessageBox.Show(output);
            }
        }
    }
