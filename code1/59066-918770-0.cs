    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace events
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                button1.Click += new EventHandler(button1_Click);
            }
    
            void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Hi!");
            }
        }
    }
