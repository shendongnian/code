    Button1_Click(RoutedEventArgs e, object o)
    {
        if(RadioButton1.Checked) # Single Room
        {
            TextBox1.Text = RadioButton1.Text;
        }
        if(RadioButton2.Checked) # Double Room
        {
            TextBox1.Text = RadioButton2.Text;
        }
        if(RadioButton3.Checked) # Triple room
        {
            TextBox1.Text = RadioButton3.Text;
        }
    }
