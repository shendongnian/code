    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    namespace XAMPP_starter
    {
        public partial class Form1 : Form
        {
            private string _xamppPanelPath;
            public Form1()
            {
                // Your absolute path to the XAMPP panel (for eg.:)
                _xamppPanelPath = @"C:\xampp\xampp-control.exe";
                InitializeComponent();
            }
            private void startMySqlAndAppache_Click(object sender, EventArgs e)
            {
                // Start the XAMPP Panel with this code
                Process.Start(_xamppPanelPath);
            }
        }
    }
