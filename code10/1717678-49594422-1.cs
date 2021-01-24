    int i = 0;
    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if(((TextBox)sender).Text != string.Empty)
        {
            System.Diagnostics.Debug.WriteLine("Hello " + ++i);
        }
     }
