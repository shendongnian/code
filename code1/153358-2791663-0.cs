    private void comboBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
       string findString = string.Empty;
        comboBox1.SelectedIndex = comboBox1.FindString(e.KeyChar.ToString());
       if(comboBox1.SelectedIndex > -1){e.Handled = true;}
    }
