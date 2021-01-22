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
    
            private void button1_Click(object sender, EventArgs e)
            {
                string message = "You did not enter a server name. Cancel this operation?";
                string caption = "No Server Name Specified";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
    
                // Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
        }
    }
