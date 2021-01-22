    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace test
    {
        public partial class Form1 : Form
        {
            bool checkBoxChecked;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void dialogToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Form2 dialog = new Form2();
                dialog.CheckBoxChecked = this.checkBoxChecked;
                dialog.ShowDialog();
    
                this.checkBoxChecked = dialog.CheckBoxChecked;
            }
        }
    }
