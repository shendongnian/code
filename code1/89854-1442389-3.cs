    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Craft
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                var f = new Form2();            
                f.FormClosing += ClosingMonitorer;
                f.Show();
    
                var g = new Form3();
                g.FormClosing += ClosingMonitorer;
                g.Show();
            }
    
            void ClosingMonitorer(object sender, FormClosingEventArgs e)
            {            
                MessageBox.Show((sender as Form).Text + " is closing");
            }
    
            
    
        }
    }
