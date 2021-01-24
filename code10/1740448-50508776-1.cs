    ICommand commandSelector { get; set; }
    
    private void commandSelectorExecute(object o)
    {
        if (checkbox)
           DoSmth();
        else 
           DoSmthElse();
    }
