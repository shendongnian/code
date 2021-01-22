    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                if (MessageBox.Show("The text in this file has changed. Do you want to save changes?", "TextEditor - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    MessageBox.Show("yes");
                }
                else
                {
                    MessageBox.Show("no");
                }
    
    
            }
        }
    }
