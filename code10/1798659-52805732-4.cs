    using System;
    using System.Windows.Forms;
    
    namespace TwoForms
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                int userVal = int.Parse(textBox2.Text);
                Form1.counter += userVal;
            }
    
            private void textBox2_TextChanged(object sender, EventArgs e)
            {
    
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                textBox1.Text = Form1.counter.ToString();
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
    
            }
        }
    }
