    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace MessageBoxFont
    {
        public partial class Message : Form
        {
            public Message(String text)
            {
                InitializeComponent();
                tbxMessage.Text = text;
            }
            private void btnOK_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
