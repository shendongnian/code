       private void button1_Click(object sender, EventArgs e)
        {
            ToolStripDropDown popup = new ToolStripDropDown();
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;
            ToolStripControlHost host = new ToolStripControlHost(frm);
          
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            popup.Items.Add(host);
            popup.Show(button1, button1.Left - 10, button1.Top + (int)(button1.Height / 2));
        }
    
        Form2 frm = new Form2();
        private void Form1_Load(object sender, EventArgs e)
        {
            frm.TopLevel = false;
        }
    }
     
