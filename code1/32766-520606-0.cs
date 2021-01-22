     private void button2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item1 = new ToolStripMenuItem("Menu1");
            ToolStripMenuItem subMenuitem1 = new ToolStripMenuItem("SubMenu");
            item1.DropDownItems.Add(subMenuitem1);
            this.contextMenuStrip1.Items.Add(item1);
            subMenuitem1.MouseDown += new MouseEventHandler(subMenuitem1_MouseDown);
            this.contextMenuStrip1.Show(this.button2,new Point(0,0));
        }
    
        void subMenuitem1_MouseDown(object sender, MouseEventArgs e)
        {
            //e.Button will determine which button was clicked.
            MessageBox.Show(e.Button.ToString());
        }
