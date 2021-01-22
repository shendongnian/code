    using System;
    using System.Windows.Forms;
    
    namespace CheckBox
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                listBox1.Items.Add(DataGenerator1());
            }
            private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {
                listBox1.Items.Add(DataGenerator2());
            }
    
            private DateTime DataGenerator1()
            {
                // this is just a sample, put what you want here.
                return DateTime.Now;
            }
    
            private DateTime DataGenerator2()
            {
                // this is just a sample, put what you want here.
                return DateTime.Now;
            }
        }
    }
