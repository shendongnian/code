    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WsTest
    {
        public partial class PhpWsForm : Form
        {
            private localhost.MyWebService ws;
    
            public PhpWsForm()
            {
                InitializeComponent();
                ws = new WsTest.localhost.MyWebService();
                // The line below is the part that I forgot!
                ws.CookieContainer = new System.Net.CookieContainer();
            }
    
            private void butSetVal_Click(object sender, EventArgs e)
            {
                ws.setName(txtSetVal.Text);
            }
    
            private void butGetVal_Click(object sender, EventArgs e)
            {
                txtGetVal.Text = ws.getName();
            }
        }
    }
