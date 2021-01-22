    private void DialogOpenedHandler(object sender, EventArgs e)
    {
        OnItemDialogOpened(new ItemEventArgs((YourItemClass)sender);
    }
    
    protected virtual OnItemDialogOpened(ItemEventArgs e)
    {
        // call event here 
    }
