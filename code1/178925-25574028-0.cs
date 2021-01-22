    string input = null;
    Color color = Color.White;
    TextBoxText_Changed(object sender, EventsArgs e)
    {
       input = TextBox.Text;
    }
    
    Button_Click(object sender, EventsArgs e)
    {
       color = Color.FromName(input)
    }
