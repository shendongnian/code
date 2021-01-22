    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void textBox1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Click1");
            }
            private void textBox2_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Click2");
            }
        }
    }
