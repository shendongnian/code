    private void dynamicbutton_Click(Object sender, System.EventArgs e)
    {
        Control control = (Control) sender;
        label1.Text = sender.Tag.ToString();
    }
