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
    
            bool CanExpand = true;
    
            private void treeView1_DoubleClick(object sender, EventArgs e)
            {
                CanExpand = false;
            }
    
            private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
            {
                if (CanExpand)
                    Application.DoEvents();
                else
                    e.Cancel = true;
            }
        }
    }
