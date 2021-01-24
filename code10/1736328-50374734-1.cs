    // I want to be able to call this from other code
    public void SaveItem()
    {
        // ...
    }
    // Hook up the event handler using a lambda expression
    saveButton.Click += (sender, args) => SaveItem();
