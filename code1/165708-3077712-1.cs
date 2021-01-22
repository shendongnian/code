    public event HandleItemAdded ItemAdded;
    // .. some other stuff
    public void RaiseItemAdded(ItemAddedEventArgs e)
    {
        if(ItemAdded != null)
            ItemAdded(this,e);
    }
    // ... now for your AddToList
    public void AddToList()
    {
        
        RaiseItemAdded(new ItemAddedEventArgs(txtName.Text,txtEmail.Text, txtPhone.Text);
    }
