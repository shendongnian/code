    int count = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        TextBox textbox = new TextBox();
        textbox.Location = new Point(60, 25 * count);
        textbox.Size = new Size(301, 20);
        textbox.Name = "textbox_" + (count + 1);
        textbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseClick);
        textbox.TextChanged += new System.EventHandler(this.TextBox_Changed);
        panel1.Controls.Add(textbox);
        count++;
        if (count == 4)
        {
            MessageBox.Show("");
            button1.Enabled = false;
        }
    }
    
    private void TextBox_MouseClick(object sender, MouseEventArgs e)
    {
        TextBox txtName = (TextBox)this.Controls.Find("textbox_1", true)[0];
        TextBox txth = (TextBox)this.Controls.Find("textbox_2", true)[0];
    
        if (txtName != null)
        {
    
        }
    }
