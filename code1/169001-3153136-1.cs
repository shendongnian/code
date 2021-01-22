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
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            public bool CheckBoxChecked
            {
                get { return cbxForm2.Checked; }
                set { cbxForm2.Checked = value; }
            }
    
            private void OK_Click(object sender, EventArgs e)
            {
                if (cbxForm2.Checked == true)
                {
                    cbxForm2.Checked = true;
                }
            }
        }
    }
