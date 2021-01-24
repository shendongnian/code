    private void ClickEvent(object sender, EventArgs e)
    {
        if(sender is Label)
        {
            Label l = sender as Label;
            //Do anything with label
        }
        else if(sender is Button)
        {
            Button b = sender as Button;
            //Do anything with button
        }
        else
        {
            MessageBox.Show("Unknown component");
            //Or
            throw new Exception("Unknown component");
        }
    }
