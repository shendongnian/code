    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Control lastControlEntered = null;
    
            public Form1()
            {
                InitializeComponent();
    
                foreach (Control c in Controls)
                    if (!(c is Button)) c.Enter += new EventHandler(c_Enter);
            }
    
            void c_Enter(object sender, EventArgs e)
            {
                if (sender is Control)
                    lastControlEntered = (Control)sender;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                label1.Text = lastControlEntered == null ? "No last control" : lastControlEntered.Name;
            }
        }
    }
