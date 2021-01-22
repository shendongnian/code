    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace example_string_to_int
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string a = textBox1.Text;
                // this turns the text in text box 1 into a string
                int b;
                if (!int.TryParse(a, out b))
                {
                    MessageBox.Show("this is not a number");
                }
                else
                {
                    textBox2.Text = a+" is a number" ;
                }
                // then this if statment says if the string not a number display an error elce now you will have an intager.
            }
        }
    }
