    //
    // this handler's only responsibility is updating the item info label:
    //
    void lstModules_ItemSelectionChanged(object sender,
                                         ListViewItemSelectionChangedEventArgs e)
    {
        if (e.IsSelected)
        {
            // an item has been selected; update the label, e.g.:
            lblModuleDetails.Text = e.Item.Text;
        }
        else
        {
            // some item has been de-selected; clear the label:
            lblModuleDetails.Text = string.Empty;
        }
    }
