    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TestPicture
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                button1.SendToBack();
    
                pictureBox1.Click += button1_Click;
            }
    
            private void button1_Enter(object sender, EventArgs e)
            {
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            }
        
            private void button1_Leave(object sender, EventArgs e)
            {
                pictureBox1.BorderStyle = BorderStyle.None;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Test");
            }
    
        }
    }
