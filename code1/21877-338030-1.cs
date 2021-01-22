    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
    
            public void UnhandledThreadExceptionHandler(object sender, ThreadExceptionEventArgs e) {
                this.HandleUnhandledException(e.Exception);
            }
    
            public void HandleUnhandledException(Exception e) {
                // do what you want here.
                if (MessageBox.Show("An unexpected error has occurred. Continue?",
                    "My application", MessageBoxButtons.YesNo, MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button2) == DialogResult.No) {
                    Application.Exit();
                }
            }
    
            private void button1_Click(object sender, EventArgs e) {
                throw new ApplicationException("Exception");
            }
    
        }
    }
