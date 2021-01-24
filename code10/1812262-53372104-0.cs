    // Handler for the first Entry
    private void Entry1_TextChanged(object s, TextChangedEventArgs e)
    {
        HandleTheTextChanged(e.NewText);
    }
    
    // Handler for the second Entry
    private void Entry2_TextChanged(object s, TextChangedEventArgs e)
    {
        HandleTheTextChanged(e.NewText);
    }
    
    // Common code
    private void HandleTheTextChanged(string newText)
    {
        // Do your stuff
    }
