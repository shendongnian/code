    protected void button_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if (button.Attributes["ListBox"] != null)
        {
            ListBox listBox = (ListBox)this.FindControl(button.Attributes["ListBox"]);
            string selected = listBox.SelectedValue;
            //do stuff
        }
    }
