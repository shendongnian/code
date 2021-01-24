    private void TextBox_MouseClick(object sender, MouseEventArgs e)
    {
        Control[] txtName = this.Controls.Find("textbox_1", true);
        Control[] txth = this.Controls.Find("textbox_2", true);
    
        if ((TextBox)txtName[0] != null)
        {
            MessageBox.Show("Test");
        }
    }
