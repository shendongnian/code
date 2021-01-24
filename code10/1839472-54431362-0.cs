    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string strCmdText;
                strCmdText = "Rscript.exe [directory here]\\script.R 10 arg2"; //what comes after script.R are the arguments you are passing. 
                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            }
        }
    }
