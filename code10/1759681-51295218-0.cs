    private void button1_Clicked(object sender, EventArgs e)
    {
        string temporaryText = textbox1.Text;
        textbox1.Text = textbox2.Text;
        textbox2.Text = temporaryText;
    }
