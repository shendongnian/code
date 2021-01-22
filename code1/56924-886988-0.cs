    Button button = sender as Button;
    if( button != null )
    {
       MessageBox.Show("Button " + button.Name + " was clicked");
    }
    else
    {
       MessageBox.Show("Not a button?");
    }
