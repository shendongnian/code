    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp27
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                contextMenuStrip1.MouseLeave += ContextMenuStrip1_MouseLeave;
            }
    
            private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
            {
                contextMenuStrip1.Hide();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                contextMenuStrip1.Show(button1, new Point(0, button1.Height));
            }
        }
    }
