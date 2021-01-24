    public void setCarCmb(long id)
    {
        // Cast the items to the type we're looking for
        // and get the FirstOrDefault that matches our Id
        var car = comboCars.Items.Cast<Cars>().FirstOrDefault(c => c.Id == id);
        // If there was a match, select the item and disable the combobox
        if (car != null)
        {
            comboCars.SelectedItem = car;
            comboCars.Enabled = false;
        }
    }
