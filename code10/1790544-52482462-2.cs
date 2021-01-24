    using System;
    using System.Windows.Forms;
    using ClassLibrary1;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Class1.MissingSnapshots += Class1_MissingSnapshots;
            }
    
            private void Class1_MissingSnapshots(object sender, EventArgs e)
            {
    
            }
        }
    }
