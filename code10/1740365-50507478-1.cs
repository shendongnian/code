    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CyUSB;
    using Microsoft.Win32;
    
    namespace Automation_v1_0_0
    {
        public partial class FormMain : Form
        {
            bool keysActivated = true;
    
            public FormMain()
            {
                InitializeComponent();
            }
    
            private void FormMain_KeyDown(object sender, KeyEventArgs e)
            {
                    if (e.KeyCode == Keys.F7)
                    {
                        FormSettings settings = new FormSettings();
                        settings.ShowDialog();
                    }
                
            }
        }
    }
