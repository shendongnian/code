    TextEdit amountBox = sender as TextEdit; 
    if (amountBox == null) 
        return; 
    int value;
    if (int.TryParse(amountBox.Text, out value))
    {
        // do something with value
        e.Cancel = false;
    }
    else 
    {
        // do something if it failed
        e.Cancel = true;
    }
