    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace formload
    {
        public partial class FormA : Form
        {
            public FormA()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                FormB frm = new FormB();
                MessageBox.Show(frm.MyProperty);
                frm = null;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                FormB frm = new FormB();
                frm.ShowDialog();
                MessageBox.Show(frm.MyProperty);
                frm = null;
            }
        }
    }
